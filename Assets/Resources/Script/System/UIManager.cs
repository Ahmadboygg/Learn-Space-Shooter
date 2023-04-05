using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel = null;
    PlayerControl playerControl;

    void Awake()
    {
        gameOverPanel.gameObject.SetActive(false);
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
        playerControl.OnGameOverUI += ShowGameOverUI;
    }

    void ShowGameOverUI()
    {
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
