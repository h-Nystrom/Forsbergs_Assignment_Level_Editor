using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace LevelEditor.DeveloperTools{
    [RequireComponent(typeof(Camera))]
    public class MouseEditing : MonoBehaviour{
        [SerializeField] LayerMask layerMask;
        [SerializeField] TileManager tileManager;
        UserControls userInput;
        Vector2 mousePosition;
        RaycastHit2D hit;
        int currentTileIndex;
        //TODO: Toggle between tile types with nr buttons
        //TODO: Multiple selections when dragging the mouse
        //TODO: Research how to save the maps
        //TODO: Save/load maps
        //TODO: Create InputController;
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
            //Debug.DrawRay(Cam.ScreenToWorldPoint(mousePosition), Vector3.forward * 10,Color.red,10f);
            if(IsMouseBlockedByUi())
                return;
            hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(mousePosition), Vector3.forward, 10f,
                layerMask);
            if(hit.collider == null || tileManager.TileTypes.Count == 0)
                return;
            var tile = hit.collider.gameObject.GetComponent<Tile>();
            tile.ChangeTileType(tileManager.TileTypes[currentTileIndex]);
        }
        //TODO:Extra: Add an IEnumerator that paints tiles when the mouse is pressed. 

        bool IsMouseBlockedByUi(){
            return EventSystem.current.IsPointerOverGameObject();
        }

        void OnEnable(){
            userInput.Enable();
        }
        void OnDisable(){
            userInput.Disable();
        }
    }
}

