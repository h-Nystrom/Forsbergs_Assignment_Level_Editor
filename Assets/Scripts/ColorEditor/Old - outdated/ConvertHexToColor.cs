using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class ConvertHexToColor : MonoBehaviour{
        
        [SerializeField]Slider[] sliders = new Slider[5];
    
        public void OnUpdateColor(string hexValue){
            Color color;
            var htmlValue = $"#{hexValue}";
            if (!ColorUtility.TryParseHtmlString(htmlValue, out color) || sliders.Length != 5) return;
            sliders[0].value = color.r;
            sliders[1].value = color.g;
            sliders[2].value = color.b;
            sliders[3].value = color.a;
            sliders[4].value = color.grayscale;

        }
    
    }
}

