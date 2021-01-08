using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LevelEditor.DeveloperTools{
    [RequireComponent(typeof(Camera))]
    public class MouseEditing : MonoBehaviour{
        [SerializeField] LayerMask layerMask;
        [SerializeField] LevelResources levelResources;
        Image buttonUiBorder;
        int currentTileIndex;
        RaycastHit2D hit;
        Vector2 mousePosition;
        UserControls userInput;
        Camera Cam => GetComponent<Camera>();

        void Awake(){
            userInput = new UserControls();
            userInput.UserAction.LeftMouseClick.performed += ctx => OnClick();
            userInput.UserAction.MousePosition.performed += ctx => mousePosition = ctx.ReadValue<Vector2>();
        }

        void OnEnable(){
            userInput.Enable();
        }

        void OnDisable(){
            userInput.Disable();
        }

        public void OnChangeTileType(int tileIndex){
            currentTileIndex = tileIndex;
        }

        void OnClick(){
            //Debug.DrawRay(Cam.ScreenToWorldPoint(mousePosition), Vector3.forward * 10,Color.red,10f);
            if (IsMouseBlockedByUi() || levelResources.TileTypes.Count == 0)
                return;
            hit = Physics2D.Raycast(Cam.ScreenToWorldPoint(mousePosition), Vector3.forward, 10f,
                layerMask);
            if (hit.collider == null || levelResources.TileTypes.Count == 0)
                return;
            var tile = hit.collider.gameObject.GetComponent<Tile>();
            tile.ChangeTileType(levelResources.TileTypes[currentTileIndex]);
            levelResources.TileTypesInGrid[tile.Index] = tile.TileType;
        }

        bool IsMouseBlockedByUi(){
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}