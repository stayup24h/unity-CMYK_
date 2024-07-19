using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool isActive;
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
    }

    void Update()
    {
        
    }
}
