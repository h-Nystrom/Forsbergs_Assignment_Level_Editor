using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor.UI{
    public class LevelUi : MonoBehaviour{
        [SerializeField] Text levelName;
        [SerializeField] Text createdDate;
        [SerializeField] Button loadButton;
        [SerializeField] Button destroyButton;

        void OnDestroy(){
            loadButton.onClick.RemoveAllListeners();
            destroyButton.onClick.RemoveAllListeners();
        }

        public void Setup(string levelName, long createdDate, StateManager stateManager){
            this.levelName.text = levelName;
            this.createdDate.text = $"Created: {TimeDateConverter.UnixToUtcTime(createdDate)}";
            loadButton.onClick.AddListener(delegate{ stateManager.Load(levelName); });
            destroyButton.onClick.AddListener(delegate{
                stateManager.RemoveLevel(levelName);
                Destroy(gameObject);
            });
        }
    }
}