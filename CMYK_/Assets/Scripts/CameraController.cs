using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 clickPoint;
    private Vector3 touchStart;
    
    void Awake()
    {
        Camera.main.orthographicSize = 10;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    
        if (Input.GetMouseButton(0))
        {
            Vector3 position = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + position.x, Camera.main.transform.position.y + position.y, -10);
            Debug.Log(position.x);
            Debug.Log(position.y);
        }
    }
}
