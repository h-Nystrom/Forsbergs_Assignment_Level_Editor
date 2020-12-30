using UnityEngine;

namespace LevelEditor{
    public struct TileData{

        const float Offset = 1.05f;
        public int[,] ID{ get; private set; }
        public Vector2 Position{ get; private set; }
        public void SetUp(int row, int column){
            Position = new Vector2(row * Offset,column * Offset);
            ID = new int[row,column];
        }
    }
}
