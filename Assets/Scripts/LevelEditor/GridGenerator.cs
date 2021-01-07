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
        public void GenerateGrid(int columns, int rows){
            Grid = new TileData[rows,columns];
            for (var column = 0; column < columns; column++){
                for (var row = 0; row < rows; row++){
                    var tileData = new TileData();
                    tileData.SetUp(row,column);
                    InstantiateNewGrid(tileData);
                    Grid[row, column] = tileData;
                }
            }
        }
        public void GenerateOldGrid(TileData[,] grid, int columns, int rows){
            Grid = new TileData[rows, columns];
            Grid = grid;
            for (var column = 0; column < columns; column++){
                for (var row = 0; row < rows; row++){
                    InstantiateOldGrid(Grid[row,column]);
                }
            }
        }
        
        void InstantiateNewGrid(TileData tileData){
            tileManager.SetUpNew(tileData, parent);
        }
        void InstantiateOldGrid(TileData tileData){
            tileManager.SetUp(tileData, parent);
        }
        
    }
}
