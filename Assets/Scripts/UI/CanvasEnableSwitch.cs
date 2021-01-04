using System;
using UnityEngine;

namespace UI{
    public class CanvasEnableSwitch : MonoBehaviour{
        [SerializeField] Canvas canvas;

        public void OnClickSwitch(){
            canvas.enabled = !canvas.enabled;
        }

        public void OnClick(){
            canvas.enabled = true;
        }
    }
}
