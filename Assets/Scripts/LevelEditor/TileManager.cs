using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    [CreateAssetMenu(menuName = "LevelEditor/TileManager", fileName = "NewTileManager")]
    public class TileManager : ScriptableObject{
        const int MaxTiles = 10;
        [SerializeField] GameObject tilePrefab;
        List<TileType> tileTypes = new List<TileType>();
        public int StartingTileTypeIndex{ get; set; }
        public bool IsFull => tileTypes.Count == MaxTiles;
        public List<TileType> TileTypes => tileTypes;

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
        }

        //TODO: add start tileNr here
        public void SetUpNew(TileData tileData, Transform parent){
            tileData.TileType = tileTypes[StartingTileTypeIndex];
            var instance = Instantiate(tilePrefab, tileData.Position, Quaternion.identity, parent);
            instance.GetComponent<SpriteRenderer>().material = tileTypes[StartingTileTypeIndex].material;
            instance.GetComponent<Tile>().NewSetUp(tileData, tileTypes[StartingTileTypeIndex]);
        }
        public void SetUp(TileData tileData, Transform parent){
            var instance = Instantiate(tilePrefab, tileData.Position, Quaternion.identity, parent);
            instance.GetComponent<SpriteRenderer>().material = tileData.TileType.material;
            instance.GetComponent<Tile>().SetUp(tileData);
        }
    }
}
