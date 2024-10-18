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

    private Dictionary<string, int> requiredPoints = new Dictionary<string, int>
    {
        { SceneNamesEnum.Level1.ToString(), 10 },
        { SceneNamesEnum.Level2.ToString(), 20 },
        { SceneNamesEnum.Level3.ToString(), 30 }
    };

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
    }

    public void LoadScene(string sceneName)
    {
        previousSceneName = currentSceneName;
        currentSceneName = sceneName;
        sceneLoadTime = Time.time;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel(int playerScore)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        int nextLevel = levelNames.IndexOf(currentSceneName) + 1;

        if (requiredPoints.ContainsKey(currentSceneName))
        {
            if (playerScore >= requiredPoints[currentSceneName])
            {
                if (nextLevel < levelNames.Count)
                {
                    LoadScene(levelNames[nextLevel]);
                }

                else
                {
                    LoadScene(winSceneName);
                }
            }

            else
            {
                LoadScene(LoseSceneName);
            }
        }

        else
        {
            Debug.Log("Not currently inside a level");
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
}