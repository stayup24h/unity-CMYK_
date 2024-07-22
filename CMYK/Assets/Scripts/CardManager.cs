using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject canvas;
    private RectTransform canvasRect;
    public GameObject cardPrefab;
    public Transform cardMng;
    public GameObject[] card = new GameObject[4];
    private Vector3[] cardPos = new Vector3[4];
    private RectTransform[] cardRect = new RectTransform[4];
    private float x,y;

    void Start()
    {
        canvasRect = canvas.GetComponent<RectTransform>();
        x = canvasRect.anchoredPosition.x;
        y = canvasRect.anchoredPosition.y;

        for(int i=0; i<4; i++)
        {
            cardPos[i] = new Vector3((x/4)*(2*i-3),-y/2,0);
        }
        Debug.Log(cardPos[0]);
        Debug.Log(cardPos[1]);
        Debug.Log(cardPos[2]);
        Debug.Log(cardPos[3]);
        TurnStart();
    }
    void TurnStart()
    {
        for(int i=0; i<4; i++)
        {
            card[i] = Instantiate(cardPrefab, cardMng);
            card[i].GetComponent<CardScript>().SetCard(i);
            card[i].GetComponent<RectTransform>().anchoredPosition = cardPos[i];
        }
    }
}
