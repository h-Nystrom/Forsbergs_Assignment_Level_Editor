using System;
using LevelEditor.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ColorEditor{
    public class ColorEditorController : MonoBehaviour
    {
        //TODO: string event for hex
        //TODO: apply changes
        [SerializeField] InputField nameInputField;
        [SerializeField] EditingColor editingColor;
        [SerializeField] HexUi hexUi;
        TileButtonUI tileButtonUI;
        
        public string TileNameInput{ get; set;}

        public void SelectedTile(TileButtonUI tileButtonUI){
            this.tileButtonUI = tileButtonUI;
            hexUi.OnUpdateColor(ColorUtility.ToHtmlStringRGBA(tileButtonUI.TileType.material.color));
            nameInputField.text = tileButtonUI.name;
        }
        
        public void OnApplyChanges(){
            tileButtonUI.TileType.material.color = editingColor.Material.color;
            tileButtonUI.TileType.name = nameInputField.text;
            tileButtonUI.ApplyEdit();
            nameInputField.text = null;
            tileButtonUI = null;
        }
    }
    
}
