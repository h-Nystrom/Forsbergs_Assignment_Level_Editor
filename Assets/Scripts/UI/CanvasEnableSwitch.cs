using UnityEngine;

namespace UI{
    public class CanvasEnableSwitch : MonoBehaviour{
        [SerializeField] Canvas canvas;
        bool isEnabled;
        public void OnClick(){
            isEnabled = !isEnabled;
            canvas.enabled = isEnabled;
        }
    }
}
