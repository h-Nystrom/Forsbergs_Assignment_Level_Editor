using System;
using UnityEngine;

namespace LevelEditor{
    [Serializable]
    public class TileType{
        public Material material;
        [HideInInspector]public Vector2 position;
        public string name;
    }
}