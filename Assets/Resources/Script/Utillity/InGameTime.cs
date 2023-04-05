using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InGameTime
{
    public static string timeString;
    public static float pausedTime;
    public static GameObject player;
    static float startingTime;
    static float endingTime;
    static int minutes;
    static int seconds;

    public static string GameTimeSinceLevelLoad()
    {
        startingTime = Time.timeSinceLevelLoad;
        minutes = Mathf.FloorToInt(startingTime / 60f);
        seconds = Mathf.FloorToInt(startingTime - (minutes * 60f));
        timeString = $"{minutes.ToString("F0")}.{seconds.ToString("F0")}";
        return timeString;
    }

    public static int GetMinutesGameOverTime()
    {
        minutes = Mathf.FloorToInt((startingTime / 60f));

        return minutes;
    }

    public static int GetSecondsGameOverTime()
    {
        seconds = Mathf.FloorToInt(startingTime - (minutes * 60f));

        return seconds;
    }
}
