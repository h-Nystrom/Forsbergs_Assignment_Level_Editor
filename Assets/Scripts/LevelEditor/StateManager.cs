using System.Collections.Generic;
using UnityEngine;
using SaveSystem;

namespace LevelEditor{
    public class StateManager : MonoBehaviour{
        const int MaxLevels = 10;
        [SerializeField]TileManager tileManager;
        [SerializeField]TileMapController tileMapController;
        public LevelObject CurrentLevel{ get; private set; }
        public List<string> savedLevelNames{ get; private set; }

        void Awake(){
            tileManager.Clear();
            savedLevelNames = FindSavedFiles();
        }
        public void CreateNewLevel(){
            if(tileManager.TileTypes.Count == 0)
                return;
            tileMapController.GenerateNewTileMap();
            CurrentLevel = new LevelObject{
                name = tileMapController.LevelName,
                createdTimeDate = TimeDateConverter.CurrentUnixTime()
            };
            Save();
        }
        public void Save(){
            if(CurrentLevel == null)
                return;
            var oldCreatedTimeDate = CurrentLevel.createdTimeDate;
            var oldLevelName = CurrentLevel.name;
            CurrentLevel = new LevelObject{
                tileTypes = tileManager.TileTypes,
                createdTimeDate = oldCreatedTimeDate,
                name = oldLevelName
            };
            
            print(SerializationManager.Save(CurrentLevel));
        }

        public List<string> FindSavedFiles(){
            return SerializationManager.GetSavedFileNames();
        }
        public void Load(){
            if(CurrentLevel == null)
                return;
            CurrentLevel = SerializationManager.Load(CurrentLevel.name);
            print(CurrentLevel.name);
        }
        public void Quit()
        {
            //TODO: ask for saving before here
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }
}
