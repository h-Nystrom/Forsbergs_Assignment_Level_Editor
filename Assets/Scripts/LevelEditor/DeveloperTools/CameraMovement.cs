using UnityEngine;

namespace LevelEditor.DeveloperTools{
    public class CameraMovement : MonoBehaviour{
        [SerializeField] float moveSpeed = 2;    
        UserControls userInput;
        Vector3 inputDir;
        void Awake(){
            userInput = new UserControls();
            userInput.UserAction.MovementDir.performed += ctx => inputDir = ctx.ReadValue<Vector2>();
            userInput.UserAction.MovementDir.canceled += ctx => inputDir = Vector2.zero;
        }

        void FixedUpdate(){
            transform.position += inputDir.normalized * moveSpeed * Time.fixedDeltaTime;
        }
        void OnEnable(){
            userInput.Enable();
        }

        void OnDisable(){
            userInput.Disable();
        }
    }
}