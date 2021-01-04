using UnityEngine;

namespace ColorEditor{
    [CreateAssetMenu(menuName = "ColorPicker/NewColor")]
    public class EditingColor : ScriptableObject{
        
        [SerializeField] Material material;
        public static float[] SingleColors = {1,1,1,1};

        public void UpdateColor(){
            material.color = new Color(SingleColors[(int)ColorNames.Red],SingleColors[(int)ColorNames.Green],SingleColors[(int)ColorNames.Blue],SingleColors[(int)ColorNames.Alpha]);
        }
    }
}
