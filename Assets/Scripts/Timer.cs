using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float gameDurationInSeconds = 150;
    private float timeRemaining;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    private void Start()
    {
        timeRemaining = gameDurationInSeconds;
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 1)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time's Up!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public string GetTimeForDisplay()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
