using UnityEngine;
using LevelEditor;

public class CameraMovement : MonoBehaviour{
    [SerializeField] TileMap tilemap;
    void Start()
    {
        transform.position = new Vector3(tilemap.Rows*0.5f,tilemap.Columns*0.5f,0);
    }
    //Movement = MiddleMouse down inverted x value
}
