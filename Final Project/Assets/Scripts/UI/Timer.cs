using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float runningTime;
    [SerializeField] TextMeshProUGUI timeText;

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
        }
    }

    public void IncTime()
    {
        runningTime += 5;
    }
}