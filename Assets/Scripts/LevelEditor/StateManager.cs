using UnityEngine;

namespace LevelEditor{
    public class StateManager : MonoBehaviour
    {
        public void Quit()
        {
            //TODO: ask for saving before here
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }
}
