using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace LevelEditor{
    public class TileMapController : MonoBehaviour{
        
        [SerializeField]TileManager tileManager;
        readonly GridGenerator gridGenerator = new GridGenerator();
        int columns = 10;
        int rows = 10;
        public string LevelName{ get; set; }
        public float Columns{
            get => columns;
            set => columns = (int)value;
        }
        public float Rows{
            get => rows;
            set => rows = (int)value;
        }
        void Start(){
            GenerateNewTileMap();
        }
        public void Load(LevelObject levelObject){
            RemoveTiles();
            gridGenerator.SetUp(tileManager, transform);
            gridGenerator.GenerateOldGrid(levelObject.tileTypesGrid, levelObject.rows, levelObject.columns);
        }
        public void GenerateNewTileMap(){
            if(tileManager.TileTypes.Count == 0)
                return;
            RemoveTiles();
            gridGenerator.SetUp(tileManager, transform);
            gridGenerator.GenerateGrid(columns, rows);
        }
        void RemoveTiles(){
            var tiles = transform.childCount;
            for (var i = 0; i < tiles; i++){
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}

