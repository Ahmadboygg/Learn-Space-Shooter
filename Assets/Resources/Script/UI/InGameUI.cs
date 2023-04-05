using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public TMP_Text timeText = null;
    public TMP_Text scoreText = null;
    
    public List<GameObject> healthBar;
    public List<GameObject> ammoBar;

    CharacterStatus characterStatus;
    int currentHealth;
    int currentAmmo;
    
    void Awake()
    {
        characterStatus = GameObject.Find("Player").GetComponent<CharacterStatus>();
    }

    void Update()
    {
        timeText.text = InGameTime.GameTimeSinceLevelLoad();
        scoreText.text = Score.GetScore().ToString("F0");

        currentHealth = characterStatus.GetHealth();
        for(int i = 0; i < healthBar.Count; i++)
        {
            if (i < currentHealth)
            {
                healthBar[i].gameObject.SetActive(true);
            }
            else
            {
                healthBar[i].gameObject.SetActive(false);
            }
        }

        for(int i = 0; i < ammoBar.Count; i ++)
        {
            if(i < currentAmmo)
            {
                ammoBar[i].gameObject.SetActive(true);
            }
            else
            {
                ammoBar[i].gameObject.SetActive(false);
            }
        }
    }
}
