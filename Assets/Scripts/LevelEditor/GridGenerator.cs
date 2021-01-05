using UnityEngine;

namespace LevelEditor{
    public class GridGenerator{
        Transform parent;
        TileManager tileManager;
        public TileData[,] Grid{ get; private set;}
        public void SetUp(TileManager tileManager, Transform parent){
            this.tileManager = tileManager;
            this.parent = parent;
        }
        public void GenerateGrid(TileData[,] grid, int columns, int rows){
            Grid = grid;
            for (var column = 0; column < columns; column++){
                for (var row = 0; row < rows; row++){
                    Grid[row, column].SetUp(row,column);
                    InstantiateGrid(Grid[row, column]);
                }
            }
        }
        private void InstantiateGrid(TileData tileData){
           tileManager.SetUp(tileData, parent);
        }
    }
}
