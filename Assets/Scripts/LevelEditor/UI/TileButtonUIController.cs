using System.Collections.Generic;
using ColorEditor;
using LevelEditor.DeveloperTools;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace LevelEditor.UI{
    public class TileButtonUIController : MonoBehaviour{
        [SerializeField] LevelResources levelResources;
        [SerializeField] ColorEditorController colorEditorController;
        [SerializeField] TileButtonUI tileUiPrefab;
        [SerializeField] MouseEditing mouseEditing;
        [SerializeField] CanvasEnableSwitch canvasEnableSwitch;
        [SerializeField] TileType[] protectedDefaultTileTypes = new TileType[2];
        TileButtonUI currentlySelected;
        readonly TileType[] defaultTileTypes = new TileType[2];
        readonly List<TileButtonUI> tileButtonUIs = new List<TileButtonUI>();

        void Start(){
            AddStartTileUi();
            InstantiateUiButtons();
        }

        public void AddStartTileUi(){
            ClearTileUi();
            levelResources.StartingTileTypeIndex = 0;
            if (levelResources.TileTypes.Count != 0) return;
            for (var i = 0; i < protectedDefaultTileTypes.Length; i++){
                defaultTileTypes[i] = new TileType
                    {material = new Material(Shader.Find("Sprites/Default")), name = "New Tile"};
                defaultTileTypes[i].material.color = protectedDefaultTileTypes[i].material.color;
                defaultTileTypes[i].name = protectedDefaultTileTypes[i].name;
                levelResources.Add(defaultTileTypes[i]);
            }
        }

        public void ClearTileUi(){
            if (tileButtonUIs.Count == 0)
                return;
            foreach (var tileButtonUi in tileButtonUIs) Destroy(tileButtonUi.gameObject);
            tileButtonUIs.Clear();
        }

        public void CreateNewTile(){
            if (levelResources.IsFull)
                return;
            var instance = Instantiate(tileUiPrefab, transform);
            var index = levelResources.TileTypes.Count;
            var tileType = new TileType{material = new Material(Shader.Find("Sprites/Default")), name = "New Tile"};
            tileType.material.color = Color.white;
            levelResources.Add(tileType);
            levelResources.StartingTileTypeIndex = index;
            instance.SetUp(levelResources.TileTypes[index], levelResources, this, canvasEnableSwitch, colorEditorController);
            tileButtonUIs.Add(instance);
            if (currentlySelected != null)
                currentlySelected.OnDeSelected();
            tileButtonUIs[index].OnSelected();
            currentlySelected = tileButtonUIs[index];
            ChangeTileOnClick(index);
        }

        public void DestroyTile(){
            if (currentlySelected == null){
                levelResources.StartingTileTypeIndex = 0;
                return;
            }

            levelResources.Remove(currentlySelected.TileType);
            tileButtonUIs.Remove(currentlySelected);
            Destroy(currentlySelected.gameObject);
            currentlySelected = null;
            levelResources.StartingTileTypeIndex = 0;
        }

        public void ChangeTileOnClick(int buttonId){
            mouseEditing.OnChangeTileType(buttonId);
        }

        public void ChangeBorderUiIndicator(int buttonId){
            if (currentlySelected != null)
                currentlySelected.OnDeSelected();
            currentlySelected = tileButtonUIs[buttonId];
            currentlySelected.OnSelected();
        }

        public void InstantiateUiButtons(){
            foreach (var tileType in levelResources.TileTypes){
                var instance = Instantiate(tileUiPrefab, transform);
                instance.SetUp(tileType, levelResources, this, canvasEnableSwitch, colorEditorController);
                tileButtonUIs.Add(instance);
            }

            tileButtonUIs[0].OnSelected();
            ChangeTileOnClick(0);
            currentlySelected = tileButtonUIs[0];
        }
    }
}