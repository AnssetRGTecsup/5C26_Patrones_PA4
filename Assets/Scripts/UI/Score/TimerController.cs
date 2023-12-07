using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining, timeText);
            }
        }
    }
    public void DisplayTime(float timeToDisplay, TextMeshProUGUI timeText)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
