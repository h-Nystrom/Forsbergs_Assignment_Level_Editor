using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    [CreateAssetMenu(menuName = "LevelEditor/TileManager", fileName = "NewTileManager")]
    public class TileManager : ScriptableObject{
        const int MaxTiles = 10;
        List<TileType> tileTypes = new List<TileType>();
        GameObject tilePrefab;

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
        public void SetUp(TileData tileData, Transform parent){
            var instance = Instantiate(tilePrefab, tileData.Position,Quaternion.identity, parent);
            instance.GetComponent<SpriteRenderer>().material = tileTypes[0].material;
            instance.GetComponent<Tile>().SetUp(tileData,tileTypes[0]);
        }
    }
    [Serializable]
    public class TileType{
        public Material material;
        public string name;
    }
}
