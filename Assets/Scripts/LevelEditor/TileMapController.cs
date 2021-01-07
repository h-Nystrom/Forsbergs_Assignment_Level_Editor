using System;
using System.Data;
using UnityEngine;

namespace LevelEditor{
    public class TileMapController : MonoBehaviour{
        
        [SerializeField]TileManager tileManager;
        readonly GridGenerator gridGenerator = new GridGenerator();
        int columns = 10;
        int rows = 10;
        public TileData[,] TileGrid{ get; set; }
        public string LevelName{ get; set; }
        public float Columns{
            get => columns;
            set => columns = (int)value;
        }
        public float Rows{
            get => rows;
            set => rows = (int)value;
        }
        void Start(){//TODO: Change to public void Create();
            GenerateNewTileMap();
            //Invoke(nameof(RemoveTiles),5f);
            //Invoke(nameof(TestLoad), 10f);
        }
        public void Load(){//TODO: add TileData[,] param
            RemoveTiles();
            GenerateOldTileMap(TileGrid);
        }

        public void TestLoad(){
            GenerateOldTileMap(TileGrid);
        }
        public void GenerateNewTileMap(){
            if(tileManager.TileTypes.Count == 0)
                return;
            RemoveTiles();
            gridGenerator.SetUp(tileManager, transform);
            gridGenerator.GenerateGrid(columns, rows);
            TileGrid = gridGenerator.Grid;
        }
        public void GenerateOldTileMap(TileData[,] tileGridData){
            RemoveTiles();
            gridGenerator.SetUp(tileManager, transform);
            gridGenerator.GenerateOldGrid(tileGridData, tileGridData.GetLength(0), tileGridData.GetLength(1));
            TileGrid = gridGenerator.Grid;
        }
        void RemoveTiles(){
            var tiles = transform.childCount;
            for (var i = 0; i < tiles; i++){
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}

