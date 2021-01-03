using System;
using LevelEditor;
using LevelEditor.DeveloperTools;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor.UI{
    public class TileButtonUI : MonoBehaviour{
        TileSO tileSo;
        [SerializeField]Image borderUi;
        [SerializeField]Button button;
        [SerializeField] Text text;
        int id;
        public void SetUp(TileSO tileSo, int id, TileButtonUIController tileButtonUIController){
            this.id = id;
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = tileSo.TileMaterial.color;
            button.colors = colorBlock;
            transform.name = tileSo.name;
            text.text = tileSo.name;
            button.onClick.AddListener(delegate {tileButtonUIController.ChangeTileOnClick(id);});
            button.onClick.AddListener(delegate {tileButtonUIController.ChangeBorderUiIndicator(id);});
        }

        void OnDestroy(){
            button.onClick.RemoveAllListeners();
        }
        public void OnDeSelected(){
            borderUi.color = Color.black;
        }
        public void OnSelected(){
            borderUi.color = Color.red;
        }
    }
}

