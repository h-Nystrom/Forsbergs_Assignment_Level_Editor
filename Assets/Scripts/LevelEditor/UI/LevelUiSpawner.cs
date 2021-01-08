using UnityEngine;

namespace LevelEditor.UI{
    public class LevelUiSpawner : MonoBehaviour{
        [SerializeField] LevelUi levelUiPrefab;

        public void UpdateUi(StateManager stateManager, LevelObject levelObject){
            var instance = Instantiate(levelUiPrefab, transform);
            instance.Setup(levelObject.name, levelObject.createdTimeDate, stateManager);
        }
    }
}