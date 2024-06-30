public class GameSpace
{
    public bool cyan;
    public bool magenta;
    public bool yellow;
    public bool keyPlate;
    public int turn;
    public int x;
    public int y;

    public GameSpace(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public void Reset()
    {
        cyan = false;
        magenta = false;
        yellow = false;
        keyPlate = false;
        turn = 0;
    }

    public void ColorUpdate()
    {

    }
}