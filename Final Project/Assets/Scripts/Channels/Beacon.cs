using UnityEngine;

public class Beacon : MonoBehaviour
{
    private static Beacon instance;
    [SerializeField] public BallHoleCollisionChannel ballHoleCollisionChannel;
    [SerializeField] public GameStateChannel gameStateChannel;
    [SerializeField] public TimerChannel timerChannel;
    [SerializeField] public PlayerScoreChannel playerScoreChannel;
    [SerializeField] public BallChannel ballChannel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public static Beacon GetInstance()
    {
        return instance;
    }
}