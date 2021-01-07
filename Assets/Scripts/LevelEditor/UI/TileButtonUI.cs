using System;
using ColorEditor;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor.UI{
    public class TileButtonUI : MonoBehaviour{
        
        [SerializeField]Image borderUi;
        [SerializeField]Button editButton;
        [SerializeField]Button tileButton;
        [SerializeField]Image tileImage;
        [SerializeField]Text text;
        TileManager tileManager;
        ColorEditorController colorEditorController;
        public int Id{ get; private set; }
        public TileType TileType{ get; private set;}
        public void SetUp(TileType tileType, TileManager tileManager, TileButtonUIController tileButtonUIController, CanvasEnableSwitch canvasEnableSwitch,ColorEditorController colorEditorController){
            this.tileManager = tileManager;
            TileType = tileType;
            tileImage.material = TileType.material;
            transform.name = TileType.name;
            text.text = TileType.name;
            this.colorEditorController = colorEditorController;
            editButton.onClick.AddListener(delegate{ OnSelectEditClick(tileButtonUIController, canvasEnableSwitch, colorEditorController);});
            tileButton.onClick.AddListener(delegate{ OnSelectTileClick(tileButtonUIController);});
        }

        public void ApplyEdit(){
            text.text = TileType.name;
            tileImage.material.color = TileType.material.color;
        }
        void OnSelectEditClick(TileButtonUIController tileButtonUIController, CanvasEnableSwitch canvasEnableSwitch, ColorEditorController colorEditorController){
            colorEditorController.SelectedTile(this);
            OnSelectTileClick(tileButtonUIController);
            canvasEnableSwitch.OnClick();
        }
        void OnSelectTileClick(TileButtonUIController tileButtonUIController){
            var index = tileManager.Find(TileType);
            tileButtonUIController.ChangeTileOnClick(index);
            tileButtonUIController.ChangeBorderUiIndicator(index);
            tileManager.StartingTileTypeIndex = index;
        }
        public void OnDeSelected(){
            borderUi.color = Color.black;
        }
        public void OnSelected(){
            borderUi.color = Color.red;
        }
    }
}

