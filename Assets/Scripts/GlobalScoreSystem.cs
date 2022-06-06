using UnityEngine;
using UnityEngine.Events;
public static class GlobalScoreSystem 
{
    static GlobalScoreSystem()
    {
        GameFinished = new UnityEvent();
        PlayerScoreChanged = new UnityEvent();
        BulletsUsedChanged = new UnityEvent();
        NumberBlocksLeftChanged = new UnityEvent();
    }

    private static int playerScore;
    public static int PlayerScore
    {
        get => playerScore;
        set
        {
            playerScore = value;
            PlayerScoreChanged.Invoke();
        }
    }

    private static int bulletsUsed;
    public static int BulletsUsed
    {
        get => bulletsUsed;
        set
        {
            bulletsUsed = value;
            BulletsUsedChanged.Invoke();
        }
    }

    private static int numberBlocksLeft;
    public static int NumberBlocksLeft
    {
        get => numberBlocksLeft;
        set
        {
            numberBlocksLeft = value;
            if (numberBlocksLeft==0)
            {
                GameFinished.Invoke();
            }
            NumberBlocksLeftChanged.Invoke();
        }
    }

    public static UnityEvent GameFinished { get; }
    public static UnityEvent PlayerScoreChanged { get; }
    public static UnityEvent BulletsUsedChanged { get; }
    public static UnityEvent NumberBlocksLeftChanged { get; }

}
