using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Transform fieldMng;
    public GameObject[,] tile = new GameObject[5,5];

    void Start()
    {
        ShowTile();
    }

    void ShowTile()
    {
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {
                tile[i, j] = Instantiate(tilePrefab, fieldMng);
                tile[i, j].GetComponent<TileScript>().Set(i, j);
                if (j < 3)
                {
                    tile[i, j].transform.position = new Vector3(j+2*i, j*1.732f, 0);
                }
                else
                {
                    tile[i, j].transform.position = new Vector3(1*(4-j) + 2*i, j*1.732f, 0);
                }
            }
        }
    }
}