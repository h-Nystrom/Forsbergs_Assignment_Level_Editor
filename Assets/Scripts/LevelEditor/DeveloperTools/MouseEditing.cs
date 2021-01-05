using System;
using UnityEngine;
using UnityEngine.UI;

namespace LevelEditor.DeveloperTools{
    [RequireComponent(typeof(Camera))]
    public class MouseEditing : MonoBehaviour{
        [SerializeField] LayerMask layerMask;
        [SerializeField] TileManager tileManager;
        UserControls userInput;
        Vector2 mousePosition;
        RaycastHit2D hit;
        int currentTileIndex;
        //TODO: Show currently selected button(New script)
        //TODO: Toggle between tile types with nr buttons
        //TODO: Multiple selections when dragging the mouse
        //TODO: Research how to save the maps
        //TODO: Save/load maps
        Camera Cam => GetComponent<Camera>();
        Image buttonUiBorder;
        void Awake(){
            userInput = new UserControls();
            userInput.UserAction.LeftMouseClick.performed += ctx => OnClick();
            userInput.UserAction.MousePosition.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        }

        public void OnChangeTileType(int tileIndex){
            currentTileIndex = tileIndex;
        }
        void OnClick(){
            Debug.DrawRay(Cam.ScreenToWorldPoint(mousePosition), Vector3.forward * 10,Color.red,10f);
            hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(mousePosition), Vector3.forward, 10f,
                layerMask);
            if(hit.collider == null)
                return;
            var tile = hit.collider.gameObject.GetComponent<Tile>();
            tile.ChangeTileType(tileManager.TileTypes[currentTileIndex]);
        }
        void OnEnable(){
            userInput.Enable();
        }

        void OnDisable(){
            userInput.Disable();
        }
    }
}

