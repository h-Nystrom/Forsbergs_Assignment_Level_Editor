using UnityEngine;

namespace LevelEditor{
    public class TileMap : MonoBehaviour{
        TileGrid tileGrid = new TileGrid();
        [SerializeField]TileSO[] tileData;
        [SerializeField] TileNames tileNames;
        void Start(){
            tileGrid.SetUp(tileData[(int) tileNames], transform);
            tileGrid.GenerateGrid(true);
        }
    }
    public enum TileNames{
        Grass,
        Water
    }
}

