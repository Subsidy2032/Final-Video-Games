using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private int playerScore;

    private SceneManagerWrapper sceneManager;

    private void Start()
    {
        sceneManager = SceneManagerWrapper.GetInstance();

        nextLevelButton.onClick.AddListener(OnNextLevel);
        mainMenuButton.onClick.AddListener(OnMainMenu);
    }

    private void OnNextLevel()
    {
        sceneManager.LoadNextLevel();
    }

    private void OnMainMenu()
    {
        sceneManager.LoadScene(SceneNamesEnum.StartScreen.ToString());
    }
}
