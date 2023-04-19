using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] Vector2 spawnTimeRange;
    [SerializeField] Vector2 xRange;

    private float spawnTime;
    private float xPosition;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
        Invoke("Spawn", spawnTime);
    }

    private void Spawn(){
        xPosition = Random.Range(xRange.x, xRange.y);
        position = new Vector3(xPosition, transform.position.y);

        Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
        spawnTime = Random.Range(spawnTimeRange.x, spawnTimeRange.y);
        Invoke("Spawn", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
