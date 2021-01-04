using UnityEngine;

namespace ColorEditor{
    [CreateAssetMenu(menuName = "ColorPicker/NewColor")]
    public class EditingColor : ScriptableObject{
        
        public static float[] SingleColors = {1,1,1,1};
        [SerializeField] Material material;
        
        public void UpdateColor(){
            material.color = new Color(SingleColors[(int)ColorNames.Red],SingleColors[(int)ColorNames.Green],SingleColors[(int)ColorNames.Blue],SingleColors[(int)ColorNames.Alpha]);
            HexUi.HexUiScript.UpdateText();
        }
    }
}
