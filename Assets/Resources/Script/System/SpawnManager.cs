using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> obstacle = null;
    public float minimumSpawnTime = 0f;
    public float maximumSpawnTime = 0f;
    public float spawnAngle = 0f;
    float widthRange;
    float heightRange;
    float currentSpawnTime;
    Vector2 spawnRange;
    Vector2 spawnSize;
    GameObject newObstacle;
    
    void Awake()
    {
        spawnRange = new Vector2(widthRange,heightRange);
        heightRange = Camera.main.orthographicSize + 1f;
        widthRange = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update()
    {
        if(Time.time > currentSpawnTime)
        {
            spawnRange = new Vector2(Random.Range(-widthRange,widthRange),heightRange);
            float currentSpawnAngle = Random.Range(-spawnAngle, spawnAngle);
            newObstacle = Instantiate(obstacle[Random.Range(0,obstacle.Count)],spawnRange,Quaternion.Euler(Vector3.forward * currentSpawnAngle));
            spawnSize = new Vector2(Random.Range(1,5),Random.Range(1,5));
            spawnSize.x = Mathf.Clamp(spawnSize.x, spawnSize.x, spawnSize.y);
            spawnSize.y = Mathf.Clamp(spawnSize.y, spawnSize.y, spawnSize.x);
            newObstacle.transform.localScale = Vector2.one * spawnSize;
            currentSpawnTime = Mathf.Lerp(minimumSpawnTime, maximumSpawnTime, Difficulty.GetDifficultyPercent()) + Time.time;
        }
    }
}
