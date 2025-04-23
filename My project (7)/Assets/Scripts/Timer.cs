using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public TMP_Text display;
    [SerializeField] float timerLength; 
    float remainingTime = 1; // This isn't actually ever 1 but if it's 0 which is the default the script breaks
    float startTime;
    bool timeUpCalled = false;
    public GameEnding gameEnding;

    // Start is called before the first frame update
    void Start()
    {
        // Sets start time to current time to reset timer
        startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        // If there's time remaining, decrease the remaining time and update the timer text, otherwise call TimeUp
        if (remainingTime > 0)
        {
            remainingTime = timerLength - (Time.time - startTime);
            if (remainingTime < 0)
            {
                remainingTime = 0; // Not technically necessary but without this the timer display hits -0.01 which looks a bit weird
            }
            display.text = Math.Round(remainingTime, 2).ToString("0.00");
        }
        else
        {
            if (!timeUpCalled)
            {
                // If time is up and TimeUp hasn't been called, call it once, then set timeUpCalled to prevent calling it again
                TimeUp();
                timeUpCalled = true;
            }
        }
    }
    void TimeUp()
    { 
        Debug.Log("time up");
        // Put whatever you want to happen when time runs out here
        gameEnding.CaughtPlayer();
    }
}
