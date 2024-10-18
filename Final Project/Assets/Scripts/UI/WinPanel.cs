using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private int playerScore;

    private SceneManagerWrapper sceneManager;

    private void Start()
    {
        sceneManager = SceneManagerWrapper.GetInstance();

        nextLevelButton.onClick.AddListener(OnNextLevel);
        restartGameButton.onClick.AddListener(OnRestartGame);
        mainMenuButton.onClick.AddListener(OnMainMenu);
    }

    private void OnNextLevel()
    {
        sceneManager.LoadNextLevel();
    }

    private void OnRestartGame()
    {
        sceneManager.LoadScene(SceneNamesEnum.Level1.ToString());
    }

    private void OnMainMenu()
    {
        sceneManager.LoadScene(SceneNamesEnum.StartScreen.ToString());
    }
}
