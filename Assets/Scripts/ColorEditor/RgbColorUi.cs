using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class RgbColorUi : BaseColorUi{
        [SerializeField] Slider grayScaleSlider;
        [SerializeField] InputField grayScaleInputField;
        protected override void Awake(){
            base.Awake();
            grayScaleSlider.onValueChanged.AddListener(delegate{ rgbaColor.GrayScaleValue = grayScaleSlider.value; });
            grayScaleSlider.onValueChanged.AddListener(delegate{ grayScaleInputField.text = Calculations.ConvertToString255(rgbaColor.Value);});
            grayScaleInputField.onEndEdit.AddListener(delegate{Calculations.ConvertToClampedFloat(grayScaleInputField.text, rgbaColor.GrayScaleValue);});
            
            grayScaleSlider.onValueChanged.AddListener(delegate{rgbaColor.UpdateColor();});
        }
        protected override void OnDestroy(){
            grayScaleSlider.onValueChanged.RemoveAllListeners();
            grayScaleInputField.onEndEdit.RemoveAllListeners();
            base.OnDestroy();
        }
    }
}