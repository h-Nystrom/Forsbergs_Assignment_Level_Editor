using System;
using UnityEngine;

namespace ColorEditor{
    [CreateAssetMenu(menuName = "ColorPicker/RGBAColor")]
    public class RgbaColor : ScriptableObject{
        
        [SerializeField] ColorNames colorName;
        [SerializeField] VoidEvent updateColorEvent;
        public float Value{ get; set; }
        public string ConvertToString => $"{Value * 255}";

        public float ConvertToFloat(string value){
            var convertedValue = Mathf.Clamp(float.Parse(value), 0, 255);
            Value = convertedValue;
            return convertedValue;
        }
        public void UpdateColor(){
            EditingColor.SingleColors[(int) colorName] = Value;
            updateColorEvent?.Invoke();
        }
    }
    [Serializable]
    public enum ColorNames{
        Red,
        Green,
        Blue,
        Alpha
    }
}

