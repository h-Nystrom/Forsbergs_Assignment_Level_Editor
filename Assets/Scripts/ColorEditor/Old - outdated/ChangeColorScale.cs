using System;
using UnityEngine.UI;
using UnityEngine;

namespace ColorEditor{
    public class ChangeColorScale : ChangeSingleColor{
        [SerializeField] Slider grayScaleSlider;
        float grayScaleValue = 1;
        public float CurrentColorValue => Mathf.Clamp(ColorValue, 0,grayScaleValue);

        void Start(){
            grayScaleSlider.onValueChanged.AddListener(delegate{ GrayScale(grayScaleSlider.value);});
        }

        void GrayScale(float grayScaleValue){
            this.grayScaleValue = grayScaleValue;
            updateColorEvent?.Invoke();
        }
    }
}

