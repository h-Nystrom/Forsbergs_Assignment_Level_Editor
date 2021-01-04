using System;
using System.Collections.Generic;
using LevelEditor;
using LevelEditor.DeveloperTools;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor.UI{
    public class TileButtonUIController : MonoBehaviour{
        [SerializeField] TileSO[] tileSo;
        [SerializeField] TileButtonUI tileUiPrefab;
        [SerializeField] MouseEditing mouseEditing;
        [SerializeField] CanvasEnableSwitch canvasEnableSwitch;
        readonly List<TileButtonUI> tileButtonUIs = new List<TileButtonUI>();
        TileButtonUI currentlySelected;
        void Awake(){
            for(int i = 0; i < tileSo.Length; i++){
                var instance = Instantiate(tileUiPrefab, transform);
                instance.SetUp(tileSo[i], i, this, canvasEnableSwitch);
                tileButtonUIs.Add(instance);
            }
            tileButtonUIs[0].OnSelected();
            currentlySelected = tileButtonUIs[0];
        }
        public void ChangeTileOnClick(int buttonId){
            var tileNames = (TileNames)buttonId;
            mouseEditing.OnChangeTileType(tileNames);
        }
        public void ChangeBorderUiIndicator(int buttonId){
            currentlySelected.OnDeSelected();
            currentlySelected = tileButtonUIs[buttonId];
            currentlySelected.OnSelected();
        }
    }
}

