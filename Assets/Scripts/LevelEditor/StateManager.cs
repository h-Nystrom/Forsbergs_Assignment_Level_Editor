using System;
using UnityEngine;
using System.Collections.Generic;
using ColorEditor;

namespace LevelEditor{
    public class StateManager : MonoBehaviour{
        //TODO var of list with LevelObjects!
        const int MaxLevels = 10;
        [SerializeField]TileManager tileManager;
        [SerializeField] TileMapController tileMapController;
        int currentLevelIndex;

        public LevelObject CurrentLevelObject{ get; private set; }
        public List<string> SavedData{ get; private set; }

        // void Awake(){
        //     //TODO: Read JsonFile and save to string list!
        // }

        public void CreateNewLevel(){
            if(tileManager.TileTypes.Count == 0)
                return;
            tileMapController.GenerateNewTileMap();
            var level = new LevelObject{
                name = tileMapController.LevelName,
                Tiles = tileMapController.TileGrid,
                tileTypes = tileManager.TileTypes,
                createdTimeDate = TimeDateConverter.CurrentUnixTime()
            };
            //TODO: Save level here
        }
        // public void Save(){
        //     // JsonUtility.FromJsonOverwrite(SavedData[currentLevelIndex], 
        //     //     CurrentLevelObject.UpdateLevel(tileMap.TileGrid,tileManager.TileTypes.ToArray()));
        //     // print(SavedData[currentLevelIndex]);
        //     
        // }
        // public void OnDestroySavedLevel(int levelIndex){
        //     // //LevelObjects.RemoveAt(levelIndex);
        //     // //TODO: ReWriteJsonFile
        //     // if(levelIndex != currentLevelIndex)
        //     //     return;
        //     // //TODO: ReloadScene if currentLevel!
        // }
        // public void Load(int levelIndex){
        //     // currentLevelIndex = levelIndex;
        //     // JsonUtility.FromJson(SavedData[levelIndex]);
        //     //TODO: Send info to TileButtonUIController!
        //     //TODO: Send info
        // }
        // public void Reset(){
        //     //TODO: reset json file
        //     //TODO: ReloadScene
        // }
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
