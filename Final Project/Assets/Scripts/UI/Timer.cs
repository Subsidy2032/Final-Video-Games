using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float runningTime;
    [SerializeField] TextMeshProUGUI timeText;
    TimerChannel timerChannel;
    AddTimeChannel addTimeChannel;

    private void Start()
    {
        Beacon beacon = Beacon.GetInstance();
        timerChannel = beacon.timerChannel;
        addTimeChannel = beacon.addTimeChannel;
        addTimeChannel.AddTime += AddTime;
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

    public void AddTime(int seconds)
    {
        runningTime += seconds;
    }

    private void OnDestroy()
    {
        if (addTimeChannel != null)
        {
            addTimeChannel.AddTime -= AddTime;
        }
    }
}