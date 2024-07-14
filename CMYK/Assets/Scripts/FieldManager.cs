using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public GameSpace[,] gameSpace = new GameSpace[5,5];

    void Start()
    {
        gameSpace[0, 0] = new GameSpace(false);
        gameSpace[0, 1] = new GameSpace(false);
        gameSpace[0, 2] = new GameSpace(true);
        gameSpace[0, 3] = new GameSpace(false);
        gameSpace[0, 4] = new GameSpace(false);
        gameSpace[1, 0] = new GameSpace(false);
        gameSpace[1, 1] = new GameSpace(true);
        gameSpace[1, 2] = new GameSpace(true);
        gameSpace[1, 3] = new GameSpace(true);
        gameSpace[1, 4] = new GameSpace(false);

        for (int i = 2; i < 5; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                gameSpace[i,j] = new GameSpace(true);
            }
        }
    }
}
