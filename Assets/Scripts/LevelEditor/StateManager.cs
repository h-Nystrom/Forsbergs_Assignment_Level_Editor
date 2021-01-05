using System;
using UnityEngine;

namespace LevelEditor{
    public class StateManager : MonoBehaviour, ISaving{
        void Awake(){
            
        }

        public void Quit()
        {
            //TODO: ask for saving before here
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }

        public void Save(){
            throw new NotImplementedException();
        }

        public void Load(){
            throw new NotImplementedException();
        }

        public void Reset(){
            throw new NotImplementedException();
        }
    }
    [Serializable]
    public class LevelObject{
        public TileData[,] Tiles;
        public TileType[] tileTypes;//Found in tileManager
        [HideInInspector]public int createdTimeDate;
    }

    public interface ISaving{
        void Save();
        void Load();
        void Reset();
    }
}
