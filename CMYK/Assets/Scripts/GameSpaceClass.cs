public class GameSpace
{
    public bool isActive;
    public bool isCyan;
    public bool isMagenta;
    public bool isYellow;
    public bool isKeyPlate;
    public int turn;
    public int x;
    public int y;

    public GameSpace(bool _isActive)
    {
        isActive = _isActive;
    }

    public void Reset()
    {
        isCyan = false;
        isMagenta = false;
        isYellow = false;
        isKeyPlate = false;
        turn = 0;
    }

    public void ColorUpdate()
    {

    }
}