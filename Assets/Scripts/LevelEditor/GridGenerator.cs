using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    public class GridGenerator{
        const float Offset = 1.05f;
        Transform parent;
        LevelResources levelResources;

        public void SetUp(LevelResources levelResources, Transform parent){
            this.levelResources = levelResources;
            this.parent = parent;
        }

        public void GenerateGrid(int columns, int rows){
            for (var column = 0; column < columns; column++)
            for (var row = 0; row < rows; row++){
                var position = new Vector2(row * Offset, column * Offset);
                levelResources.SetUpNew(position, parent);
            }
        }

        public void GenerateOldGrid(List<TileType> tileTypeList){
            for (var i = 0; i < tileTypeList.Count; i++) levelResources.SetUp(tileTypeList[i], parent);
        }
    }
}