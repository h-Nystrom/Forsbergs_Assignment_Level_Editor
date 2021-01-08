using UnityEngine;
using UnityEngine.Serialization;

namespace LevelEditor{
    public class TileMapController : MonoBehaviour{
        [SerializeField] LevelResources levelResources;
        [SerializeField] GameObject tileParentPrefab;
        GameObject currentTileParent;
        readonly GridGenerator gridGenerator = new GridGenerator();
        int columns = 10;
        int rows = 10;
        public string LevelName{ get; set; }

        public float Columns{
            get => columns;
            set => columns = (int) value;
        }

        public float Rows{
            get => rows;
            set => rows = (int) value;
        }
        public void RemoveTiles(){
            if(currentTileParent == null)
                return;
            Destroy(currentTileParent);
            currentTileParent = null;
        }

        public void Load(LevelObject levelObject){
            RemoveTiles();
            var tileParent = Instantiate(tileParentPrefab, transform.position, Quaternion.identity, transform);
            gridGenerator.SetUp(levelResources, tileParent.transform);
            gridGenerator.GenerateOldGrid(levelObject.tileTypesGrid);
            currentTileParent = tileParent;
        }

        public void GenerateNewTileMap(){
            RemoveTiles();
            var tileParent = Instantiate(tileParentPrefab, transform.position, Quaternion.identity, transform);
            gridGenerator.SetUp(levelResources, tileParent.transform);
            gridGenerator.GenerateGrid(columns, rows);
            currentTileParent = tileParent;
        }
    }
}