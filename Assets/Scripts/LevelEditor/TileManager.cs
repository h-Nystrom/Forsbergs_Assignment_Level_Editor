using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    [CreateAssetMenu(menuName = "LevelEditor/TileManager", fileName = "NewTileManager")]
    public class TileManager : ScriptableObject{
        const int MaxTiles = 10;
        [SerializeField] GameObject tilePrefab;
        List<TileType> tileTypes = new List<TileType>();
        List<TileType> tileTypesInGrid = new List<TileType>();
        public int StartingTileTypeIndex{ get; set; }
        public bool IsFull => tileTypes.Count == MaxTiles;
        public List<TileType> TileTypes => tileTypes;
        public List<TileType> TileTypesInGrid => tileTypesInGrid;

        public void Add(TileType tileType){
            tileTypes.Add(tileType);
        }

        public void Remove(TileType tileType){
            tileTypes.Remove(tileType);
        }

        public int Find(TileType tileType){
            return tileTypes.IndexOf(tileType);
        }

        public void Clear(){
            tileTypes.Clear();
            tileTypesInGrid.Clear();
        }
        public void SetUpNew(Vector2 position, Transform parent){
            var tileType = tileTypes[StartingTileTypeIndex];
            tileType.position = position;
            SetUp(tileType, parent);
        }
        public void SetUp(TileType tileType, Transform parent){
            var instance = Instantiate(tilePrefab, tileType.position, Quaternion.identity, parent);
            instance.GetComponent<SpriteRenderer>().material = tileType.material;
            instance.GetComponent<Tile>().SetUp(tileType);
            tileTypesInGrid.Add(tileType);
        }
    }
}
