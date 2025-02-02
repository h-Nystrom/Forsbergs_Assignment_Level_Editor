﻿using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class HexUi : MonoBehaviour{
        [SerializeField] InputField inputField;
        [SerializeField] Slider[] sliders = new Slider[4];
        [SerializeField] Material material;

        void Awake(){
            inputField.onEndEdit.AddListener(delegate{ OnUpdateColor(inputField.text); });
            UpdateText();
        }

        void OnDestroy(){
            inputField.onEndEdit.RemoveAllListeners();
        }

        public void UpdateText(){
            inputField.text = ColorUtility.ToHtmlStringRGBA(material.color);
        }

        public void OnUpdateColor(string hexValue){
            var htmlValue = $"#{hexValue}";
            if (!ColorUtility.TryParseHtmlString(htmlValue, out var color)) return;
            sliders[0].value = color.r;
            sliders[1].value = color.g;
            sliders[2].value = color.b;
            sliders[3].value = color.a;
        }
    }
}