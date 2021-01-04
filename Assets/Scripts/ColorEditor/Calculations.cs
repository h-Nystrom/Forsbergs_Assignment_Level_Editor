using UnityEngine;

namespace ColorEditor{
    public struct Calculations{
        public static float ClampedFloat(float currentValue, float maxValue){
            var convertedValue = Mathf.Clamp(currentValue, 0, maxValue);
            return convertedValue;
        }
        public static float ConvertToClampedFloat(string value, float maxValue){
            return ClampedFloat(float.Parse(value)/255, maxValue);
        }
        public static string ConvertToString255(float value){
            return $"{value * 255}";
        }
    }
}