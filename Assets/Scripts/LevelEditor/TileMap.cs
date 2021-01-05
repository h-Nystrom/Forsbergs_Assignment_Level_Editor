using System;
using UnityEngine;

namespace LevelEditor{
    public class TileMap : MonoBehaviour{
        
        [SerializeField]TileManager tileManager;
        [SerializeField] int columns, rows;
        GridGenerator gridGenerator = new GridGenerator();
        TileData[,] TileGrid{ get; set; }
        public int Columns => columns;

        public int Rows => rows;

        public void Start(){
            //TODO: If save files = 0
            GenerateNewMap();
        }
        public void GenerateNewMap(){
            gridGenerator.SetUp(tileManager, transform);
            gridGenerator.GenerateGrid(new TileData[columns,rows], columns, rows);
            TileGrid = gridGenerator.Grid;
        }
    }
}

