using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button menuButton;
    [SerializeField] Button exitButton;
    [SerializeField] string startGameSceneName = SceneNamesEnum.Level1.ToString();
    [SerializeField] string openingSceneName = SceneNamesEnum.StartScreen.ToString();
    SceneManagerWrapper sceneManager;

    void Start()
    {
        restartButton.onClick.AddListener(() => RestartGame());
        menuButton.onClick.AddListener(() => BackToMenu());
        exitButton.onClick.AddListener(() => Application.Quit());
        sceneManager = SceneManagerWrapper.GetInstance();
    }

    public void RestartGame()
    {
        sceneManager.LoadScene(startGameSceneName);
    }

    public void BackToMenu()
    {
        sceneManager.LoadScene(openingSceneName);
    }
}