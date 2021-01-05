using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    [CreateAssetMenu(menuName = "LevelEditor/TileManager", fileName = "NewTileManager")]
    public class TileManager : ScriptableObject{
        List<TileType> tileTypes = new List<TileType>();
        public List<TileType> TileTypes => tileTypes;

        GameObject tilePrefab;

        public void Add(TileType tileType){
            tileTypes.Add(tileType);
        }
        public void Remove(TileType tileType){
            tileTypes.Remove(tileType);
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
