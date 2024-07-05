using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 clickPoint;
    private Vector2 touch0PrePos;
    private Vector2 touch1PrePos;
    private Vector3 touchStart;


    public int cameraSize = 10;
    public float ZoomSpeed = 0.5f;


    void Awake()
    {
        Camera.main.orthographicSize = cameraSize;
    }

    void Update()
    {
        
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    
        if(Input.GetMouseButton(0))
        {
            Vector3 position = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + position.x, Camera.main.transform.position.y + position.y, -10);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        Camera.main.orthographicSize -= scroll;

#elif UNITY_ANDROID
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        if(Input.touchCount == 1)
        {
            Vector3 position = touchStart - Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + position.x, Camera.main.transform.position.y + position.y, -10);
        }

        if(Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            touch0PrePos = touch0.position - touch0.deltaPosition;
            touch1PrePos = touch1.position - touch1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrePos - touch1PrePos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            Camera.main.orthographicSize += ZoomSpeed * deltaMagnitudeDiff;
        }
#endif
    }
}
