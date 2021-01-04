using UnityEngine;

namespace LevelEditor{
    public class TileMap : MonoBehaviour{
        
        [SerializeField]TileSO[] tileData;//ScriptableObject
        [SerializeField] TileNames startTileName;
        [SerializeField] int columns, rows;
        GridGenerator gridGenerator = new GridGenerator();

        public int Columns => columns;

        public int Rows => rows;

        void Start(){
            gridGenerator.SetUp(tileData[(int) startTileName], transform, columns, rows);
            gridGenerator.GenerateGrid(true);
        }
    }
}

