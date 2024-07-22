using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool isCyan;
    public bool isMagenta;
    public bool isYellow;
    public bool isKeyPlate;
    public int turn;
    public int x;
    public int y;
    
    

    public void Set(int _x, int _y)
    {
        x = _x;
        y = _y;
        isCyan = false;
        isMagenta = false;
        isYellow = false;
        isKeyPlate = false;
        turn = 0;

        if(x==0)
        {
            if(y!=2)
            {
                Destroy(this.gameObject);
            }
        }
        else if(x==1)
        {
            if(y==0)
            {
                Destroy(this.gameObject);
            }
            else if(y==4)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void Update()
    {
        
    }
}
