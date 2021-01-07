using System.Collections.Generic;
using ColorEditor;
using LevelEditor.DeveloperTools;
using UI;
using UnityEngine;

namespace LevelEditor.UI{
    public class TileButtonUIController : MonoBehaviour{
        [SerializeField] TileManager tileManager;
        [SerializeField] ColorEditorController colorEditorController;
        [SerializeField] TileButtonUI tileUiPrefab;
        [SerializeField] MouseEditing mouseEditing;
        [SerializeField] CanvasEnableSwitch canvasEnableSwitch;
        readonly List<TileButtonUI> tileButtonUIs = new List<TileButtonUI>();
        TileButtonUI currentlySelected;
        [SerializeField]TileType[] protectedDefaultTileTypes = new TileType[2];
        TileType[] defaultTileTypes = new TileType[2];
        
        void Start(){
            tileManager.Clear();
            tileManager.StartingTileTypeIndex = 0;
            if (tileManager.TileTypes.Count == 0){
                for (var i = 0; i < protectedDefaultTileTypes.Length; i++){
                    defaultTileTypes[i] = new TileType{material = new Material(Shader.Find("Sprites/Default")), name = "New Tile"};
                    defaultTileTypes[i].material.color = protectedDefaultTileTypes[i].material.color;
                    defaultTileTypes[i].name = protectedDefaultTileTypes[i].name;
                    tileManager.Add(defaultTileTypes[i]);
                }
            }
            InstantiateUiButtons();
        }

        void OnDestroy(){
            tileManager.Clear();
        }

        void InstantiateUiButtons(){
            
            foreach (var tileType in tileManager.TileTypes){
                var instance = Instantiate(tileUiPrefab, transform);
                instance.SetUp(tileType,tileManager, this, canvasEnableSwitch, colorEditorController);
                tileButtonUIs.Add(instance);
            }
            tileButtonUIs[0].OnSelected();
            ChangeTileOnClick(0);
            currentlySelected = tileButtonUIs[0];
        }

        public void CreateNewTile(){
            if(tileManager.IsFull)
                return;
            var instance = Instantiate(tileUiPrefab, transform);
            var index = tileManager.TileTypes.Count;
            var tileType = new TileType{material = new Material(Shader.Find("Sprites/Default")), name = "New Tile"};
            tileType.material.color = Color.white;
            tileManager.Add(tileType);
            tileManager.StartingTileTypeIndex = index;
            instance.SetUp(tileManager.TileTypes[index],tileManager, this, canvasEnableSwitch, colorEditorController);
            tileButtonUIs.Add(instance);
            if(currentlySelected != null)
                currentlySelected.OnDeSelected();
            tileButtonUIs[index].OnSelected();
            currentlySelected = tileButtonUIs[index];
            ChangeTileOnClick(index);
        }
        public void DestroyTile(){
            if (currentlySelected == null){
                tileManager.StartingTileTypeIndex = 0;
                return;
            }
                

            tileManager.Remove(currentlySelected.TileType);
            tileButtonUIs.Remove(currentlySelected);
            Destroy(currentlySelected.gameObject);
            currentlySelected = null;
            tileManager.StartingTileTypeIndex = 0;
        }
        public void ChangeTileOnClick(int buttonId){
            mouseEditing.OnChangeTileType(buttonId);
        }
        public void ChangeBorderUiIndicator(int buttonId){
            if(currentlySelected != null)
                currentlySelected.OnDeSelected();
            currentlySelected = tileButtonUIs[buttonId];
            currentlySelected.OnSelected();
        }
    }
}

