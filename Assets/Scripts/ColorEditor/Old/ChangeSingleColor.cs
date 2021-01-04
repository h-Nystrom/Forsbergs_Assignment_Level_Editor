using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ColorEditor{
    public class ChangeSingleColor : MonoBehaviour{
        [SerializeField]Slider slider;
        [SerializeField]InputField inputField;
        [SerializeField] protected VoidEvent updateColorEvent;
        public float ColorValue{ get; private set; }
        void Awake(){
            slider.onValueChanged.AddListener(delegate{ UpdateInputField(slider.value);});
            inputField.onEndEdit.AddListener(delegate{ UpdateSlider(inputField.text);});
            ColorValue = 1f;
        }

        void UpdateSlider(string value){
            var maxMinValue = float.Parse(value);
            
            if (maxMinValue > 255){
                maxMinValue = 255;
            }
            if (maxMinValue < 0){
                maxMinValue = 0;
            }
            inputField.text = maxMinValue.ToString("0");
            slider.value = maxMinValue/255;
            ColorValue = maxMinValue/255;
            updateColorEvent?.Invoke();
        }
        void UpdateInputField(float value){
            ColorValue = value;
            ConvertTo255(value);
            updateColorEvent?.Invoke();
        }

        void ConvertTo255(float value){
            value *= 255;
            inputField.text = value.ToString("0");
        }
    }
    [Serializable]
    public class VoidEvent : UnityEvent{}
    [CreateAssetMenu(fileName = "ColorPicker/ColorMaterial")]
    public class ColorMaterialSo : ScriptableObject{
        public ColorMaterialSo(Material material, Color color){
            Material = material;
            Color = color;
        }
        public Color Color{ get; }
        public Material Material{ get; }
    }
}


