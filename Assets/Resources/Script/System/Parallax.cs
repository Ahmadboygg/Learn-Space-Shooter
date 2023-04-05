using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxSpeed = 0f;
    float parallaxHeightRange;
    void Start()
    {
        parallaxHeightRange = GetComponent<SpriteRenderer>().bounds.size.y - 0.15f;
    }

    void Update()
    {
        transform.Translate(Vector2.down * parallaxSpeed * Time.deltaTime);
        if(transform.position.y < -parallaxHeightRange)
        {
            transform.position = new Vector2(transform.position.x, parallaxHeightRange);
        }
    }
}
