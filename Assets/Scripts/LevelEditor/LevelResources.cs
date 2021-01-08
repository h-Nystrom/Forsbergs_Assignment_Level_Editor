using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    [CreateAssetMenu(menuName = "LevelEditor/LevelResources", fileName = "LevelResources")]
    public class LevelResources : ScriptableObject{
        const int MaxTiles = 10;

        [SerializeField] GameObject tilePrefab;
        [HideInInspector]public List<TileType> TileTypes = new List<TileType>();

        [HideInInspector]public List<TileType> TileTypesInGrid = new List<TileType>();
        public int StartingTileTypeIndex{ get; set; }
        public bool IsFull => TileTypes.Count == MaxTiles;
        
        

        public void UpdateTiles(LevelObject levelObject){
            TileTypes = levelObject.tileTypes;
            TileTypesInGrid = levelObject.tileTypesGrid;
        }

        public void Add(TileType tileType){
            TileTypes.Add(tileType);
        }

        public void Remove(TileType tileType){
            TileTypes.Remove(tileType);
        }

        public int Find(TileType tileType){
            return TileTypes.IndexOf(tileType);
        }

        public void SetUpNew(Vector2 position, Transform parent){
            var tileType = new TileType{
                position = position,
                name = TileTypes[StartingTileTypeIndex].name,
                material = TileTypes[StartingTileTypeIndex].material
            };
            SetUp(tileType, parent);
        }
        public void SetUp(TileType tileType, Transform parent){
            var instance = Instantiate(tilePrefab, tileType.position, Quaternion.identity, parent);
            instance.GetComponent<SpriteRenderer>().material = tileType.material;
            instance.GetComponent<Tile>().SetUp(tileType, TileTypesInGrid.Count);
            TileTypesInGrid.Add(tileType);
        }
    }
}