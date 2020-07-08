﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float startTime;
    public Text FinalTime;
 
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //if (start)
        {
        float t = Time.time - startTime; // Store the tima since the timer has started

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        TimerText.text = minutes + ":" + seconds;
        Win();
        }
    }

    public void Win()
    {
        FinalTime.text = TimerText.text;
    }
}