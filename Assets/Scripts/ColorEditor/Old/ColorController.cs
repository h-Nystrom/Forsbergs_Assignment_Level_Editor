using System;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class ColorController : MonoBehaviour{
        [SerializeField]Image image;
        [SerializeField] ChangeColorScale redColorValue,greenColorValue, blueColorValue;
        [SerializeField] ChangeSingleColor alphaColorValue;
        [SerializeField] InputField inputField;
        void Start(){
            image.color = Color.white;
            CurrentColor.ColorController = this;
        }

        public void UpdateColor(){
            image.color = new Color(redColorValue.CurrentColorValue,greenColorValue.CurrentColorValue,blueColorValue.CurrentColorValue, alphaColorValue.ColorValue);
            inputField.text = ColorUtility.ToHtmlStringRGBA(image.color);
        }
    }
    public static class CurrentColor{
        public static Color Color;
        public static ColorController ColorController;

        public static void UpdateColorController(){
            ColorController.UpdateColor();
        }
    }
}

