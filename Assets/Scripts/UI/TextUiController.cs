using UnityEngine;
using UnityEngine.UI;

namespace UI{
    public class TextUiController : MonoBehaviour{
        Text Txt => GetComponent<Text>();

        public void UpdateText(float value){
            Txt.text = value.ToString("0");
        }
    }
}
