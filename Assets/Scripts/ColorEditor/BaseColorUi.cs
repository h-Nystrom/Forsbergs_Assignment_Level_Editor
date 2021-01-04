using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class BaseColorUi : MonoBehaviour{
        [SerializeField] protected RgbaColor rgbaColor;
        [SerializeField] protected HexUi hexUi;
        Slider BaseSlider => GetComponentInChildren<Slider>();
        InputField BaseInputField => GetComponentInChildren<InputField>();
        protected virtual void Awake(){
            rgbaColor.GrayScaleValue = 1;
            rgbaColor.Value = 1;
            BaseInputField.onEndEdit.AddListener(delegate{BaseSlider.value = Calculations.ConvertToClampedFloat(BaseInputField.text, 1);});
            BaseSlider.onValueChanged.AddListener(delegate{OnSliderChange(BaseSlider.value);});
        }

        void OnSliderChange(float value){
            rgbaColor.Value = value;
            BaseInputField.text = Calculations.ConvertToString255(value);
            rgbaColor.UpdateColor();
            hexUi.UpdateText();
        }
        protected virtual void OnDestroy(){
            BaseSlider.onValueChanged.RemoveAllListeners();
            BaseInputField.onEndEdit.RemoveAllListeners();
        }
    }
}
