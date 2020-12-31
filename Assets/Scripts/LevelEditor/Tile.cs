using UnityEngine;

namespace LevelEditor{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour{
        public TileData TileInfo{ get; private set; }
        public TileSO TileType{ get; private set; }

        SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

        public void SetUp(TileData tileData, TileSO tileSo){
            TileInfo = tileData;
            TileType = tileSo;
        }
        
        public void ChangeTileType(TileSO tileSo){
            TileType = tileSo;
            spriteRenderer.material = TileType.TileMaterial;
            print("Change");
        }
    }
}
