using NUnit.Framework;
using UnityEngine;
using LevelEditor;

namespace Tests
{
    public class LevelEditorTest{
        [Test]
        public void Generate2DArray(){
            GridGenerator gridGenerator = new GridGenerator();
            gridGenerator.GenerateGrid(false);
            Assert.AreEqual(gridGenerator.Grid.Length, 100);
        }
        [Test]
        public void GenerateTileAtCorrectPosition(){ 
            GridGenerator gridGenerator = new GridGenerator();
            gridGenerator.GenerateGrid(false);
            Assert.AreEqual(gridGenerator.Grid[9,5].Position, new Vector2(9*1.05f,5*1.05f));
        }
    }
}
