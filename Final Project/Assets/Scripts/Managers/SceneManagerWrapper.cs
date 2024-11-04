using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerWrapper : MonoBehaviour
{
    private static SceneManagerWrapper Instance;

    private string previousSceneName;
    private string currentSceneName;
    private string winSceneName = SceneNamesEnum.WinScreen.ToString();
    private string LoseSceneName = SceneNamesEnum.LoseScreen.ToString();
    private float sceneLoadTime;

    private List<string> levelNames = new List<string> { SceneNamesEnum.Level1.ToString(), 
        SceneNamesEnum.Level2.ToString(), 
        SceneNamesEnum.Level3.ToString() };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static SceneManagerWrapper GetInstance()
    {
        return Instance;
    }

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        sceneLoadTime = Time.time;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;
    }

    public void LoadScene(string sceneName)
    {
        previousSceneName = currentSceneName;
        currentSceneName = sceneName;
        sceneLoadTime = Time.time;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        int nextLevel = levelNames.IndexOf(currentSceneName) + 1;

        if (nextLevel < levelNames.Count)
        {
            LoadScene(levelNames[nextLevel]);
        }

        else
        {
            LoadScene(winSceneName);
        }
    }

    public string GetPreviousScene()
    {
        return previousSceneName;
    }

    public float GetElapsedTime()
    {
        return Time.time - sceneLoadTime;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}