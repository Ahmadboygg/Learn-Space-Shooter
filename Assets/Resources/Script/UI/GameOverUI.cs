using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text minutesText = null;
    public TMP_Text secondsText = null;
    public TMP_Text scoreText = null;
    void Update()
    {
        minutesText.text = InGameTime.GetMinutesGameOverTime().ToString("F0") + " Minutes";
        secondsText.text = InGameTime.GetSecondsGameOverTime().ToString("F0") + " Seconds";
        scoreText.text = Score.GetScore().ToString("F0");
    }
}
