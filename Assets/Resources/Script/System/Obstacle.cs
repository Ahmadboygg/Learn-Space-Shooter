using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamageable
{
    public float minimumSpeed = 0f;
    public float maximumSpeed = 0f;
    public float obstacleLifeTime = 0f;
    public int score;

    float currentSpeed;
    

    private void Awake()
    {
        Invoke("TakeDamage", obstacleLifeTime);
    }

    void Update()
    {
        currentSpeed = Mathf.Lerp(minimumSpeed, maximumSpeed, Difficulty.GetDifficultyPercent());
        transform.Translate(Vector2.down * currentSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            if(other.tag=="Player")
            {
                damageable.TakeDamage(1);
                TakeDamage();
            }
        }
    }

    public void TakeDamage()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage){}
    
}
