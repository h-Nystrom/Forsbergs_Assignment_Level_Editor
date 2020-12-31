using UnityEngine;

namespace LevelEditor{
    public class TileMap : MonoBehaviour{
        GridGenerator gridGenerator = new GridGenerator();
        [SerializeField]TileSO[] tileData;//ScriptableObject
        [SerializeField] TileNames startTileName;
        void Start(){
            gridGenerator.SetUp(tileData[(int) startTileName], transform);
            gridGenerator.GenerateGrid(true);
        }
    }
}

