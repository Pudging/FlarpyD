using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawnerScriptBasic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FlyingPipe;
    private float timer = 0;
    public float spawnRate = 5;
    public float heightOffset = 20;
    public float maxSpawns = 5;
    float spawnDelayTimer = 0;
    bool bossSpawned = false;
    
    void Start()
    {
     
        SpawnPipe();
        spawnDelayTimer = Time.time;
    }

    // Update is called once per frame
    void Update()

    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
            
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }


    }
    void SpawnPipe()
    {
        float lowestPoint = -heightOffset;
        float HighestPoint = heightOffset;
        if (FlyingPipe.name == "SpinningPipe" && Time.time - spawnDelayTimer > 15) {

            for (int count = 0; count < UnityEngine.Random.Range(0, maxSpawns); count++)
            {
                Instantiate(FlyingPipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, HighestPoint), 0.0f), FlyingPipe.transform.rotation);
            }
         }
        if (FlyingPipe.name == "BasicFlyingPipe")
        {
            if (Time.time - spawnDelayTimer < 30)
            {
                for (int count = 0; count < UnityEngine.Random.Range(0, maxSpawns); count++)
                {
                    Instantiate(FlyingPipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, HighestPoint), 0.0f), FlyingPipe.transform.rotation);
                }
            }
            if (Time.time - spawnDelayTimer > 30)
            {
                for (int count = 0; count < UnityEngine.Random.Range(maxSpawns, maxSpawns * maxSpawns); count++)
                {
                    Instantiate(FlyingPipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, HighestPoint), 0.0f), FlyingPipe.transform.rotation);
                }
            }
        }
        if (FlyingPipe.name == "BossPrefab" && !bossSpawned)
        {
            if (Time.time - spawnDelayTimer > 20)
            {
                Instantiate(FlyingPipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, HighestPoint), 0.0f), FlyingPipe.transform.rotation);
                bossSpawned = true;
            }
        }
    }

}
