using UnityEngine;

namespace LevelEditor{
    public class GridGenerator{
        TileData[,] grid;
        int columns = 10;
        int rows = 10;
        Transform parent;
        TileSO tileSo;
        public TileData[,] Grid => grid;

        public void SetUp(TileSO tileSo, Transform parent, int columns, int rows){
            this.columns = columns;
            this.rows = rows;
            this.tileSo = tileSo;
            this.parent = parent;
        }
        public void GenerateGrid(bool canInstantiate){
            grid = new TileData[rows,columns];
            for (var column = 0; column < columns; column++){
                for (var row = 0; row < rows; row++){
                    grid[row, column].SetUp(row,column);
                    if(canInstantiate)
                        InstantiateGrid(grid[row, column]);
                }
            }
        }
        private void InstantiateGrid(TileData tileData){
           tileSo.SetUp(tileData, parent);
        }
    }
}
