using System;
using UnityEngine;

namespace LevelEditor{
    [Serializable]
    public class TileData{
        [NonSerialized] const float Offset = 1.05f;
        public TileType TileType{ get; set;}
        public Vector2 Position{ get; private set; }
        
        public void SetUp(int row, int column){
            Position = new Vector2(row * Offset,column * Offset);
        }
    }
}
