using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using LevelEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace SaveSystem{
    public struct SerializationManager{
        static string SaveFolderPath => $"{Application.persistentDataPath}/saves";
        public static bool Save(LevelObject levelObject){
            var formatter = GetBinaryFormatter();
            if (!Directory.Exists(SaveFolderPath)){
                Directory.CreateDirectory(SaveFolderPath);
            }
            var path = $"{SaveFolderPath}/{levelObject.name}";
            var fileStream = File.Create(path);
            formatter.Serialize(fileStream,levelObject);
            fileStream.Close();
            return true;
        }
        public static bool Delete(string levelName){
            var path = $"{SaveFolderPath}/{levelName}";
             if(!File.Exists(path))
                return false;
             File.Delete(path);
             return true;
        }

        public static List<string> GetSavedFileNames(){
            var info = new DirectoryInfo(SaveFolderPath);
            var fileInfo = info.GetFiles();
            return fileInfo.Select(file => file.Name).ToList();
        }
        public static LevelObject Load(string levelName){
            var path = $"{SaveFolderPath}/{levelName}";
            if (!File.Exists(path)){
                return null;
            }
            var formatter = GetBinaryFormatter();
            var fileStream = File.Open(path, FileMode.Open);
            try{
                var levelObject = formatter.Deserialize(fileStream);
                fileStream.Close();
                return (LevelObject)levelObject;
            }
            catch (Exception e){
                Debug.LogErrorFormat("Failed to load file " + e,path);
                fileStream.Close();
                return null;
            }
        }
        static BinaryFormatter GetBinaryFormatter(){
            var formatter = new BinaryFormatter();
            var selector = new SurrogateSelector();
            var tileTypeSurrogate = new TileTypeSerializationSurrogate();
            selector.AddSurrogate(typeof(TileType),new StreamingContext(StreamingContextStates.All),tileTypeSurrogate);
            formatter.SurrogateSelector = selector;
            return formatter;
        }
    }
}
//Reference:
//https://www.youtube.com/watch?v=5roZtuqZyuw&list=WL&index=17&t=14s