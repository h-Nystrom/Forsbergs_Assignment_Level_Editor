using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class HexUi : MonoBehaviour{
        [SerializeField] InputField inputField;
        [SerializeField]Slider[] sliders = new Slider[5];
        [SerializeField] Material material;
        public static HexUi HexUiScript{ get; private set; }
        void Awake(){
            HexUiScript = this;
            inputField.onEndEdit.AddListener(delegate{OnUpdateColor(inputField.text);});
            UpdateText();
        }
        public void UpdateText(){
            inputField.text = ColorUtility.ToHtmlStringRGBA(material.color);
        }
        void OnUpdateColor(string hexValue){
            var htmlValue = $"#{hexValue}";
            if (!ColorUtility.TryParseHtmlString(htmlValue, out var color) || sliders.Length != 5) return;
            sliders[0].value = color.r;
            sliders[1].value = color.g;
            sliders[2].value = color.b;
            sliders[3].value = color.a;
            sliders[4].value = color.grayscale;
        }

        void OnDestroy(){
            inputField.onEndEdit.RemoveAllListeners();
        }
    }
}