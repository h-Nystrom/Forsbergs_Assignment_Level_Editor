using NUnit.Framework;
using UnityEngine;
using LevelEditor;

namespace Tests
{
    public class LevelEditorTest{
        [Test]
        public void Generate2DArray(){
            TileGrid tileGrid = new TileGrid();
            tileGrid.GenerateGrid(false);
            Assert.AreEqual(tileGrid.Grid.Length, 100);
        }
        [Test]
        public void GenerateTileAtCorrectPosition(){ 
            TileGrid tileGrid = new TileGrid();
            tileGrid.GenerateGrid(false);
            Assert.AreEqual(tileGrid.Grid[9,5].Position, new Vector2(9*1.05f,5*1.05f));
        }
    }
}
