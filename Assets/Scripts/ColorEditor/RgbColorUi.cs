using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class RgbColorUi : BaseColorUi{
        [SerializeField] Slider grayScaleSlider;
        [SerializeField] InputField grayScaleInputField;
        protected override void Awake(){
            base.Awake();
            grayScaleSlider.onValueChanged.AddListener(delegate{OnGrayScaleChange(grayScaleSlider.value); });
            grayScaleInputField.onEndEdit.AddListener(delegate{Calculations.ConvertToClampedFloat(grayScaleInputField.text, rgbaColor.GrayScaleValue);});
        }
        void OnGrayScaleChange(float value){
            rgbaColor.GrayScaleValue = value;
            grayScaleInputField.text = Calculations.ConvertToString255(value);
            rgbaColor.UpdateColor();
            hexUi.UpdateText();
        }
        protected override void OnDestroy(){
            grayScaleSlider.onValueChanged.RemoveAllListeners();
            grayScaleInputField.onEndEdit.RemoveAllListeners();
            base.OnDestroy();
        }
    }
}