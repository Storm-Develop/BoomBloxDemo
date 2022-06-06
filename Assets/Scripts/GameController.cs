using System;
using TMPro;
using UnityEngine;

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

    [SerializeField]
    private GameObject levelOneBlocksPrefab;

    [SerializeField]
    private CameraController cameraController;

    private GameObject currentLevelBlock;



    // Start is called before the first frame update
    void Awake()
    {
        GlobalScoreSystem.GameFinished.AddListener(GameFinished);
        GlobalScoreSystem.BulletsUsedChanged.AddListener(BulletsUsedChanged);
        GlobalScoreSystem.NumberBlocksLeftChanged.AddListener(NumberBlocksLeftChanged);
        GlobalScoreSystem.PlayerScoreChanged.AddListener(PlayerScoreChanged);

        ResetGame();
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        if (currentLevelBlock!=null)
        {
            Destroy(currentLevelBlock);
        }

        GlobalScoreSystem.BulletsUsed = 0;
        GlobalScoreSystem.NumberBlocksLeft = 0;
        GlobalScoreSystem.PlayerScore = 0;
        gameUpdatesText.text = string.Empty;
        GlobalScoreSystem.NumberBlocksLeft = totalNumberBlocks;

        currentLevelBlock = Instantiate(levelOneBlocksPrefab, gameObject.transform);
        cameraController.Target = (levelOneBlocksPrefab.transform);
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
