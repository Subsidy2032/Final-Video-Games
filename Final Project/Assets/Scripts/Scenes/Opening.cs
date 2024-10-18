using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] string startGameSceneName = SceneNamesEnum.Level1.ToString();
    SceneManagerWrapper sceneManager;

    void Start()
    {
        startButton.onClick.AddListener(() => StartGame());
        exitButton.onClick.AddListener(() => Application.Quit());
        sceneManager = SceneManagerWrapper.GetInstance();
    }

    public void StartGame()
    {
        sceneManager.LoadScene(startGameSceneName);
    }
}