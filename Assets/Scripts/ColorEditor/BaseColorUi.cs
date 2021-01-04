using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class BaseColorUi : MonoBehaviour{
        [SerializeField] protected RgbaColor rgbaColor;
        protected Slider Slider => GetComponentInChildren<Slider>();
        protected InputField InputField => GetComponentInChildren<InputField>();
        void Awake(){
            InputField.onEndEdit.AddListener(delegate{rgbaColor.ConvertToFloat(InputField.text);});
            Slider.onValueChanged.AddListener(delegate{rgbaColor.Value = Slider.value;});
            InputField.onEndEdit.AddListener(delegate{UpdateSlider(InputField.text);});
            
            Slider.onValueChanged.AddListener(delegate{InputField.text = rgbaColor.ConvertToString;});
            Slider.onValueChanged.AddListener(delegate{rgbaColor.UpdateColor();});
        }
        void UpdateSlider(string value){
            Slider.value = rgbaColor.ConvertToFloat(value);
        }
    }
}
