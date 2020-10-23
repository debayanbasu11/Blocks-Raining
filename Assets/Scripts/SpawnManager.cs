using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    Vector2 screenHalfSizeWorldUnits;
    float nextSpawnTime;
    public float spawnAngleMax;
    public Vector2 spawnSizeMinMax;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime){
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize/2f);
            GameObject newBlock = (GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
