using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    [Serializable]
    public class LevelObject{
        public string name;
        public int rows;
        public int columns;
        public List<TileType> tileTypesGrid; 
        public List<TileType> tileTypes;
        public long createdTimeDate;
    }
}