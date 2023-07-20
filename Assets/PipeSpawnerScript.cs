using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipeSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Pipe;
    public float timer = 0;
    public float spawnRate = 10;
    public float heightOffset = 10;
    void Start()
    {
        spawnRate = 5;
        SpawnPipe();
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
    void SpawnPipe ()
    {
        float lowestPoint = Pipe.transform.position.y - heightOffset;
        float HighestPoint = Pipe.transform.position.y + heightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, HighestPoint), 0.0f), Pipe.transform.rotation);

    }

}
