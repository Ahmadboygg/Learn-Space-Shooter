using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileLifeTime = 1.5f;

    Animator animator;
    Vector2 projectileDirection;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        Invoke("DestroyProjectile", projectileLifeTime);
    }
    void Update()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime, Space.Self);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       IDamageable damageable = other.GetComponent<IDamageable>();
       if(damageable != null)
       {
            if(other.tag == "Obstacle")
            damageable.TakeDamage();
            Score.score ++;
            Destroy(gameObject);
       }
    }
}
