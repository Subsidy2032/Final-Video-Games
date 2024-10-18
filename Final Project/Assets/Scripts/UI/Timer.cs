using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float runningTime;
    [SerializeField] TextMeshProUGUI timeText;
    TimerChannel timerChannel;

    private void Start()
    {
        timerChannel = Beacon.GetInstance().timerChannel;
    }

    void Update()
    {
        if (runningTime > 0)
        {
            timeText.text = "Time Remaining: " + (Mathf.FloorToInt(runningTime).ToString());
            runningTime -= Time.deltaTime;
        }

        if (runningTime <= 0)
        {
            Time.timeScale = 0f;
            timerChannel.TimeEnded(runningTime);
        }
    }

    public void IncTime()
    {
        runningTime += 5;
    }
}