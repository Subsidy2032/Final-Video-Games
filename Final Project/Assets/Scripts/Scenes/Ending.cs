using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button menuButton;
    [SerializeField] Button exitButton;
    [SerializeField] string startGameSceneName = SceneNamesEnum.Level1.ToString();
    [SerializeField] string openingSceneName = SceneNamesEnum.StartScreen.ToString();

    void Start()
    {
        restartButton.onClick.AddListener(() => RestartGame());
        menuButton.onClick.AddListener(() => BackToMenu());
        exitButton.onClick.AddListener(() => Application.Quit());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(startGameSceneName);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(openingSceneName);
    }
}