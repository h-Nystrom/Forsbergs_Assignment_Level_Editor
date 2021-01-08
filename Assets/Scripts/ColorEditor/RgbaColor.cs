using UnityEngine;

namespace ColorEditor{
    [CreateAssetMenu(menuName = "ColorPicker/RGBAColor")]
    public class RgbaColor : ScriptableObject{
        [SerializeField] ColorNames colorName;
        [SerializeField] VoidEvent updateColorEvent;
        public float Value{ get; set; }
        public float GrayScaleValue{ get; set; }

        public void UpdateColor(){
            EditingColor.SingleColors[(int) colorName] = Calculations.ClampedFloat(Value, GrayScaleValue);
            updateColorEvent?.Invoke();
        }
    }
}