using System.Collections.Generic;
using LevelEditor;
using NUnit.Framework;
using SaveSystem;
using UnityEngine;

namespace Editor
{
    public class LevelEditorTest{

        [Test]
        public void CanSaveData(){
            
            var listTileType = new List<TileType>();
            var tileType = new TileType{
                name = "Grass",
                material = new Material(Shader.Find("Sprites/Default")),
                position = new Vector2(10,0)
            };
            tileType.material.color = Color.blue;
            listTileType.Add(tileType);
            var levelObject1 = new LevelObject{
                name = "Test1",
                createdTimeDate = 100,
                tileTypes = listTileType
            };
            var levelObject2 = new LevelObject{
                name = "Test2",
                createdTimeDate = 100,
                tileTypes = listTileType
            };
            var levelObject3 = new LevelObject{
                name = "Test3",
                createdTimeDate = 100,
                tileTypes = listTileType
            };
            Assert.AreEqual(true, SerializationManager.Save(levelObject1));
            Assert.AreEqual(true, SerializationManager.Save(levelObject2));
            Assert.AreEqual(true, SerializationManager.Save(levelObject3));
        }

        [Test]
        public void CanLoadData(){
            var levelObject = SerializationManager.Load("Test1");
            Debug.Log(levelObject.name);
            Debug.Log(levelObject.createdTimeDate);
            Debug.Log(levelObject.tileTypes[0].name);
            Debug.Log(levelObject.tileTypes[0].material.color);
            Debug.Log(levelObject.tileTypes[0].position);
            Assert.AreEqual("Test1", levelObject.name);
            Assert.AreEqual(100, levelObject.createdTimeDate);
            Assert.AreEqual(1, levelObject.tileTypes.Count);
            Assert.AreEqual(new Vector2(10,0), levelObject.tileTypes[0].position);
        }

        [Test]
        public void CanDestroyData(){
            var levelName = "Test3";
            Assert.AreEqual(true,SerializationManager.Delete(levelName));
        }

        [Test]
        public void CanPutAllSavedDataFilesToList(){
            var savedFileNames = SerializationManager.GetSavedFileNames();
            foreach (var name in savedFileNames){
                Debug.Log(name);
            }
            Assert.AreEqual("Test1", savedFileNames[0]);
        }
    }
}
