using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class BaseColorUi : MonoBehaviour{
        [SerializeField] protected RgbaColor rgbaColor;
        Slider BaseSlider => GetComponentInChildren<Slider>();
        InputField BaseInputField => GetComponentInChildren<InputField>();
        protected virtual void Awake(){
            rgbaColor.GrayScaleValue = 1;
            rgbaColor.Value = 1;
            BaseInputField.onEndEdit.AddListener(delegate{BaseSlider.value = Calculations.ConvertToClampedFloat(BaseInputField.text, 1);});
            BaseSlider.onValueChanged.AddListener(delegate{rgbaColor.Value = BaseSlider.value;});
            BaseInputField.onEndEdit.AddListener(delegate{BaseSlider.value = Calculations.ConvertToClampedFloat(BaseInputField.text, 1);});
            BaseSlider.onValueChanged.AddListener(delegate{BaseInputField.text = Calculations.ConvertToString255(rgbaColor.Value);});
            BaseSlider.onValueChanged.AddListener(delegate{rgbaColor.UpdateColor();});
        }
        protected virtual void OnDestroy(){
            BaseSlider.onValueChanged.RemoveAllListeners();
            BaseInputField.onEndEdit.RemoveAllListeners();
        }
    }
}
