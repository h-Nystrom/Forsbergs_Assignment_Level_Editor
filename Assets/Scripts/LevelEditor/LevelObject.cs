using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    [Serializable]
    public class LevelObject{
        public string name;
        public TileData[,] Tiles; 
        public List<TileType> tileTypes;
        public long createdTimeDate;
        
        public string UpdateLevel(TileData[,] tiles, List<TileType> tileTypes){
            Tiles = tiles;
            this.tileTypes = tileTypes;
            return JsonUtility.ToJson(this);
        }
    }
}