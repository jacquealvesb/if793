using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotas : MonoBehaviour
{
    [SerializeField] GameObject[] gotasPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GotasSpawn());
    }

    IEnumerator GotasSpawn(){
        while(true){
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(gotasPrefab[Random.Range(0, gotasPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 1f); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
