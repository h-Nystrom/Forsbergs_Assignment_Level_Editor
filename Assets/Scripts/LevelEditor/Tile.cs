using UnityEngine;

namespace LevelEditor{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour{
        public TileData TileData{ get; private set; }
        public TileType TileType{ get; private set; }

        SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();

        public void SetUp(TileData tileData, TileType tileType){
            TileData = tileData;
            TileType = tileType;
        }
        public void ChangeTileType(TileType tileType){
            TileType = tileType;
            SpriteRenderer.material = TileType.material;
        }
    }
}
