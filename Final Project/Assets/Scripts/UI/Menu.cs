using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] Button restartButton;
    [SerializeField] Button returnButton;
    [SerializeField] Button menuButton;
    SceneManagerWrapper sceneManager;


    private bool isMenuActive = false;
    GameStateChannel gameStateChannel;
    [SerializeField] string startGameSceneName = SceneNamesEnum.Level1.ToString();
    [SerializeField] string menuSceneName = SceneNamesEnum.StartScreen.ToString();

    private void Start()
    {
        gameStateChannel = Beacon.GetInstance().gameStateChannel;
        sceneManager = SceneManagerWrapper.GetInstance();
        gameStateChannel.StateEnter += OnStateEnter;

        returnButton.onClick.AddListener(() =>
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1;
            isMenuActive = false;
        });

        restartButton.onClick.AddListener(() =>
        {
            sceneManager.LoadScene(startGameSceneName);
            Time.timeScale = 1;
            isMenuActive = false;
        });

        menuButton.onClick.AddListener(() =>
        {
            menuPanel.SetActive(false);
            isMenuActive = false;
            Time.timeScale = 1;
            sceneManager.LoadScene(menuSceneName);
        });

        AssignNamedActionTransition();
    }

    private void AssignNamedActionTransition()
    {
        var transitions = FindObjectsOfType<NamedActionTransition>();
        var buttons = FindObjectsOfType<Button>(true).ToList();
        foreach (var transition in transitions)
        {
            var selectedButton = buttons.FirstOrDefault(x => x.name.Equals(transition.ActionName));
            if (selectedButton != null)
            {
                selectedButton.onClick.AddListener(transition.DoAction);
            }
        }
    }

    private void OnStateEnter(GameState state)
    {
        if (state != null && state.stateSO.canMenu && !(sceneManager.GetElapsedTime() < 0.5))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
            isMenuActive = menuPanel.activeSelf;

            if (isMenuActive)
            {
                Time.timeScale = 0f;
            }

            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    private void OnDestroy()
    {
        if (gameStateChannel != null)
        {
            gameStateChannel.StateEnter -= OnStateEnter;
        }
    }
}
