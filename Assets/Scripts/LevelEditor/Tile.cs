using UnityEngine;

namespace LevelEditor{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour{
        public TileType TileType{ get; private set; }

        SpriteRenderer SpriteRenderer => GetComponent<SpriteRenderer>();

        public void SetUp(TileType tileType){
            TileType = tileType;
            SpriteRenderer.material = tileType.material;
        }
        public void ChangeTileType(TileType tileType){
            TileType = tileType;
            transform.name = tileType.name;
            SpriteRenderer.material = tileType.material;
        }
    }
}
