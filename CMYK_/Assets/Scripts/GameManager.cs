using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameSpace[] space = new GameSpace[19]; //게임판 생성
    
    void Start()
    {
        // 게임판 설정
        space[0] = new GameSpace(1,3);
        space[1] = new GameSpace(2,2);
        space[2] = new GameSpace(2,3);
        space[3] = new GameSpace(2,4);
        for(int i = 4; i < 19; i++)
        {
            for(int j = 3; j < 6; j++)
            {
                for(int k = 1; k < 6; k++)
                {
                    space[i] = new GameSpace(j, k);
                }
            }
        }
    }

    void NewGameStart()
    {
        for(int i = 0; i < 19; i++)
        {
            space[i].Reset();
        }
    }

    void Update()
    {
        
    }
}
