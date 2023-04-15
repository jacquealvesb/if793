using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spawnTime = 0.5f;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    private float xPosition;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(true){
            xPosition = Random.Range(minX, maxX);
            position = new Vector3(xPosition, transform.position.y);

            Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
