using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    static Managers instance;

    [SerializeField] string[] allowedScenes = { SceneNamesEnum.Level1.ToString(), SceneNamesEnum.Level2.ToString(), SceneNamesEnum.Level3.ToString() };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!IsAllowedScene(scene.name))
        {
            Destroy(gameObject);
        }
    }

    bool IsAllowedScene(string sceneName)
    {
        foreach (string allowedScene in allowedScenes)
        {
            if (allowedScene == sceneName)
            {
                return true;
            }
        }
        return false;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
