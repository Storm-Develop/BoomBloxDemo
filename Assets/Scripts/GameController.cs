using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int totalNumberBlocks;

    [SerializeField]
    private TextMeshProUGUI blocksLeftText;

    [SerializeField]
    private TextMeshProUGUI bulletsUsedText;

    [SerializeField]
    private TextMeshProUGUI playerScoreText;

    [SerializeField]
    private TextMeshProUGUI gameUpdatesText;

    // Start is called before the first frame update
    void Awake()
    {
        GlobalScoreSystem.GameFinished.AddListener(GameFinished);
        GlobalScoreSystem.BulletsUsedChanged.AddListener(BulletsUsedChanged);
        GlobalScoreSystem.NumberBlocksLeftChanged.AddListener(NumberBlocksLeftChanged);
        GlobalScoreSystem.PlayerScoreChanged.AddListener(PlayerScoreChanged);
        gameUpdatesText.text = string.Empty;
        GlobalScoreSystem.NumberBlocksLeft = totalNumberBlocks;
    }

    private void PlayerScoreChanged()
    {
        playerScoreText.text = String.Format("Total Score: {0}", GlobalScoreSystem.PlayerScore.ToString());
    }

    private void NumberBlocksLeftChanged()
    {
        blocksLeftText.text = String.Format("Blocks Left: {0}", GlobalScoreSystem.NumberBlocksLeft.ToString());
    }

    private void BulletsUsedChanged()
    {
        bulletsUsedText.text = String.Format("Bullets Used: {0}", GlobalScoreSystem.BulletsUsed.ToString());
    }

    private void GameFinished()
    {
        gameUpdatesText.text = "Game is Finished!";
    }

}
