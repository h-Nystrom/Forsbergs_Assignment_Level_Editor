﻿using UnityEngine;

namespace LevelEditor{
    [CreateAssetMenu(menuName = "LevelEditor/Tile", fileName = "NewTile")]
    public class TileSO : ScriptableObject{
        [SerializeField]Material material;
        [SerializeField]GameObject tilePrefab;
        [SerializeField] TileNames tileNames;

        public TileNames TileName => tileNames;
        public Material TileMaterial => material;
        public void SetUp(TileData tileData, Transform parent){
            var instance = Instantiate(tilePrefab, tileData.Position,Quaternion.identity, parent);
            instance.GetComponent<SpriteRenderer>().material = material;
            instance.GetComponent<Tile>().SetUp(tileData,this);
        }
    }
}
