using System;
using System.Collections.Generic;
using LevelEditor;
using LevelEditor.DeveloperTools;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor.UI{
    public class TileButtonUIController : MonoBehaviour{
        [SerializeField] TileManager tileManager;
        [SerializeField] TileButtonUI tileUiPrefab;
        [SerializeField] MouseEditing mouseEditing;
        [SerializeField] CanvasEnableSwitch canvasEnableSwitch;
        readonly List<TileButtonUI> tileButtonUIs = new List<TileButtonUI>();
        TileButtonUI currentlySelected;
        [SerializeField] TileType[] defaultTileTypes;
        void Awake(){
            if (tileManager.TileTypes.Count == 0){
                foreach (var type in defaultTileTypes){
                    tileManager.Add(type);
                }
            }
            InstantiateUiButtons();
        }

        void OnDestroy(){
            tileManager.Clear();
        }

        public void InstantiateUiButtons(){
            
            for (int i = 0; i < tileManager.TileTypes.Count; i++){
                var instance = Instantiate(tileUiPrefab, transform);
                instance.SetUp(tileManager.TileTypes[i], i, this, canvasEnableSwitch);
                tileButtonUIs.Add(instance);
            }

            tileButtonUIs[0].OnSelected();
            currentlySelected = tileButtonUIs[0];
        }

        public void ChangeTileOnClick(int buttonId){
            mouseEditing.OnChangeTileType(buttonId);
        }
        public void ChangeBorderUiIndicator(int buttonId){
            currentlySelected.OnDeSelected();
            currentlySelected = tileButtonUIs[buttonId];
            currentlySelected.OnSelected();
        }
    }
}

