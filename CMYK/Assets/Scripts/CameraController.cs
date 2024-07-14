using UnityEngine;

public class CameraController : MonoBehaviour
{
    //터치 위치 변수들
    private Vector2 clickPoint;
    private Vector2 touch0PrePos;
    private Vector2 touch1PrePos;
    private Vector3 touchStart;

    //시작시 카메라 크기
    public int cameraSize = 10;
    
    //줌속도 변수
    public float mouseZoomSpeed = 100f;
    public float touchZoomSpeed = 0.5f;


    void Awake()
    {
        Camera.main.orthographicSize = cameraSize; //카메라 크기 초기화
    }


    void Update()
    {

//untiy editor에서 구동 되는 부분
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            //터치가 시작될때 터치 시작 위치 저장
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    
        if(Input.GetMouseButton(0))
        {
            //터치 시작 위치와 현재 터치 위치를 계산해 카메라 위치 이동
            Vector3 position = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + position.x, Camera.main.transform.position.y + position.y, -10);
        }

        //마우스 스크롤을 통해 카메라 크기 변경 
        float scroll = Input.GetAxis("Mouse ScrollWheel") * mouseZoomSpeed;
        Camera.main.orthographicSize -= scroll;
        Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);

        //mobile에서 구동되는 부분
#elif UNITY_ANDROID
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)//손가락 1개의 접촉이 시작될때
        {
            //터치가 시작될때 터치 시작 위치 저장
            touchStart = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

        if(Input.touchCount == 1)//접촉된 손가락이 1일때
        {
            //터치 시작 위치와 현재 터치 위치를 비교해 카메라 위치 이동
            Vector3 position = touchStart - Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + position.x, Camera.main.transform.position.y + position.y, -10);
        }

        if(Input.touchCount == 2)//접촉된 손가락이 2일때
        {
            //각각의 터치 정보 저장
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            //각각의 터치 시작 위치 저장
            touch0PrePos = touch0.position - touch0.deltaPosition;
            touch1PrePos = touch1.position - touch1.deltaPosition;

            //터치 시작 위치와 현재 위치간의 거리를 계산
            float prevTouchDeltaMag = (touch0PrePos - touch1PrePos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            
            //카메라 크기 변경
            Camera.main.orthographicSize += touchZoomSpeed * deltaMagnitudeDiff;
            Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
        }
#endif
    }
}