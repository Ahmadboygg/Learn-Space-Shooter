using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth
    {
        get { return _currentHealth ;}
        set {_currentHealth = value ;}
    }

    int _currentHealth;
    
    void Start()
    {
        _currentHealth = maxHealth;
    }

    
    public int GetHealth()
    {
        Debug.Log(_currentHealth);
        return _currentHealth;
    }
}
