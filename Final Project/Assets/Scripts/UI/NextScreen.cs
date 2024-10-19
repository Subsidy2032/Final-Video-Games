using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{
    GameStateChannel gameStateChannel;
    [SerializeField] PlayerScoreChannel playerScoreChannel;
    [SerializeField] GameObject winPanel;

    [SerializeField] Dictionary<string, int> requiredPoints = new Dictionary<string, int>
    {
        { SceneNamesEnum.Level1.ToString(), 0 },
        { SceneNamesEnum.Level2.ToString(), 0 },
        { SceneNamesEnum.Level3.ToString(), 0 }
    };

    SceneManagerWrapper sceneManager;
    int playerScore = 0;
    string loseSceneName = SceneNamesEnum.LoseScreen.ToString();

    private void Start()
    {
        Beacon beacon = Beacon.GetInstance();
        gameStateChannel = beacon.gameStateChannel;
        gameStateChannel.StateEnter += OnStateEntered;

        playerScoreChannel.ScoreUpdate += UpdateScore;
        sceneManager = SceneManagerWrapper.GetInstance();
    }

    void UpdateScore(int score)
    {
        playerScore = score;
    }
    
    private void OnStateEntered(GameState state)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (state.stateSO.name == StateNamesEnum.LevelFinished.ToString())
        {

            if (playerScore >= requiredPoints[currentSceneName])
            {
                if (currentSceneName == SceneNamesEnum.Level3.ToString())
                {
                    sceneManager.LoadScene(SceneNamesEnum.WinScreen.ToString());
                }

                else
                {
                    winPanel.SetActive(true);
                }
            }

            else
            {
                sceneManager.LoadScene(loseSceneName);
            }
        }
    }


    private void OnDestroy()
    {
        if (gameStateChannel != null)
        {
            gameStateChannel.StateEnter -= OnStateEntered;
        }

        if (playerScoreChannel != null)
        {
            playerScoreChannel.ScoreUpdate -= UpdateScore;
        }
    }
}
