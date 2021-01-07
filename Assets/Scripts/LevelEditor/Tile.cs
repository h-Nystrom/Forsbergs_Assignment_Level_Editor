using UnityEngine;

namespace LevelEditor{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour{
        public TileData TileData{ get; private set; }
        public TileType TileType{ get; private set; }

        SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();

        public void NewSetUp(TileData tileData, TileType tileType){
            TileData = tileData;
            TileType = tileType;
        }

        public void SetUp(TileData tileData){
            TileData = tileData;
            TileType = tileData.TileType;
        }
        public void ChangeTileType(TileType tileType){
            TileType = tileType;
            var tileData = TileData;
            tileData.TileType = tileType;
            TileData = tileData;
            SpriteRenderer.material = TileType.material;
        }
    }
}
