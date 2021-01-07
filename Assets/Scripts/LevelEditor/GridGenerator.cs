using UnityEngine;
using System.Collections.Generic;

namespace LevelEditor{
    public class GridGenerator{
        const float Offset = 1.05f;
        Transform parent;
        TileManager tileManager;
        public void SetUp(TileManager tileManager, Transform parent){
            this.tileManager = tileManager;
            this.parent = parent;
        }
        public void GenerateGrid(int columns, int rows){
            var grid = new TileType[rows, columns];
            for (var column = 0; column < columns; column++){
                for (var row = 0; row < rows; row++){
                    var position = new Vector2(row * Offset, column * Offset);
                    tileManager.SetUpNew(position, parent);
                }
            }
        }

        public void GenerateOldGrid(List<TileType> tileTypeList, int columns, int rows){
            foreach (var tileType in tileTypeList){
                tileManager.SetUp(tileType, parent);
            }
        }
    }
}
