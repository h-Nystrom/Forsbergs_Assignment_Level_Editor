using UI;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor.UI{
    public class TileButtonUI : MonoBehaviour{
        TileSO tileSo;
        [SerializeField]Image borderUi;
        [SerializeField]Button editButton;
        [SerializeField]Button tileButton;
        [SerializeField]Image tileImage;
        [SerializeField]Text text;
        
        int id;

        public void SetUp(TileSO tileSo, int id, TileButtonUIController tileButtonUIController, CanvasEnableSwitch canvasEnableSwitch){
            this.id = id;
            
            tileImage.material = tileSo.TileMaterial;
            transform.name = tileSo.name;
            text.text = tileSo.name;
            editButton.onClick.AddListener(delegate{ OnSelectEditClick(tileButtonUIController, canvasEnableSwitch);});
            tileButton.onClick.AddListener(delegate{ OnSelectTileClick(tileButtonUIController);});
        }

        void OnSelectEditClick(TileButtonUIController tileButtonUIController, CanvasEnableSwitch canvasEnableSwitch){
            OnSelectTileClick(tileButtonUIController);
            canvasEnableSwitch.OnClick();
        }
        void OnSelectTileClick(TileButtonUIController tileButtonUIController){
            tileButtonUIController.ChangeTileOnClick(id);
            tileButtonUIController.ChangeBorderUiIndicator(id);
        }
        public void OnDeSelected(){
            borderUi.color = Color.black;
        }
        public void OnSelected(){
            borderUi.color = Color.red;
        }
    }
}

