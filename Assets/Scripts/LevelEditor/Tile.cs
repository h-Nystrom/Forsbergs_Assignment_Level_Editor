using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    public class Tile : MonoBehaviour{
        public TileData TileInfo{ get; private set; }
        public TileSO TileType{ get; private set; }


        public void SetUp(TileData tileData, TileSO tileSo){
            TileInfo = tileData;
            TileType = tileSo;
        }
        
        public void ChangeTileType(TileSO tileSo){
            TileType = tileSo;
        }
    }
}
