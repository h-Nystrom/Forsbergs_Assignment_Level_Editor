using System.Collections.Generic;
using LevelEditor.UI;
using SaveSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelEditor{
    public class StateManager : MonoBehaviour{
        const int MaxLevels = 6;
        [SerializeField] LevelResources levelResources;
        [SerializeField] TileMapController tileMapController;
        [SerializeField] TileButtonUIController tileButtonUIController;
        [SerializeField] LevelObjectEvent loadLevelEvent;
        bool isReady = true;
        public LevelObject CurrentLevel{ get; private set; }
        public List<LevelObject> SavedLevels{ get; } = new List<LevelObject>();

        public List<string> SavedLevelNames{ get; set; } = new List<string>();

        void Awake(){
            levelResources.TileTypes.Clear();
            levelResources.TileTypesInGrid.Clear();
            UpdateSavedLevels();
            foreach (var level in SavedLevels) loadLevelEvent?.Invoke(this, level);
        }

        public void CreateNewLevel(){
            if (!isReady || levelResources.TileTypes.Count == 0 || SavedLevels.Count == MaxLevels)
                return;
            if(CurrentLevel != null)
                Save();
            isReady = false;
            levelResources.TileTypesInGrid.Clear();
            tileMapController.GenerateNewTileMap();
            CurrentLevel = new LevelObject{
                name = tileMapController.LevelName,
                createdTimeDate = TimeDateConverter.CurrentUnixTime()
            };
            tileButtonUIController.AddStartTileUi();
            tileButtonUIController.InstantiateUiButtons();
            isReady = true;
        }

        public void Save(){
            if (CurrentLevel == null)
                return;
            if (CurrentLevel.name == "")
                CurrentLevel.name = "1";
            var oldCreatedTimeDate = CurrentLevel.createdTimeDate;
            var oldLevelName = CurrentLevel.name;
            CurrentLevel = new LevelObject{
                tileTypes = levelResources.TileTypes,
                tileTypesGrid = levelResources.TileTypesInGrid,
                createdTimeDate = oldCreatedTimeDate,
                name = oldLevelName
            };
            if(!SavedLevelNames.Contains(CurrentLevel.name))
                loadLevelEvent?.Invoke(this, CurrentLevel);
            SerializationManager.Save(CurrentLevel);
            UpdateSavedLevels();
        }
        public void RemoveLevel(string levelName){
            SerializationManager.Delete(levelName);
            UpdateSavedLevels();
            if (CurrentLevel == null)
                return;
            if (levelName != CurrentLevel.name)
                return;
            levelResources.TileTypes.Clear();
            levelResources.TileTypesInGrid.Clear();
            tileMapController.RemoveTiles();
        }

        public void Load(string levelName){
            if (!isReady)
                return;
            isReady = false;
            if (!SavedLevelNames.Contains(levelName)){
                UpdateSavedLevels();
                return;
            }
            CurrentLevel = SerializationManager.Load(levelName);
            tileMapController.Load(CurrentLevel);
            levelResources.UpdateTiles(CurrentLevel);
            tileButtonUIController.ClearTileUi();
            tileButtonUIController.InstantiateUiButtons();
            isReady = true;
        }

        public void Quit(){
            //TODO: ask for saving before here
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
        void UpdateSavedLevels(){
            ClearLists();
            SavedLevelNames = FindSavedFiles();
            foreach (var levelName in SavedLevelNames) SavedLevels.Add(SerializationManager.Load(levelName));
        }

        void ClearLists(){
            if (SavedLevelNames.Count > 0)
                SavedLevels.Clear();
            if (SavedLevels.Count > 0)
                SavedLevelNames.Clear();
        }

        List<string> FindSavedFiles(){
            return SerializationManager.GetSavedFileNames();
        }
    }
}