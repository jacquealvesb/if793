using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 10f;
    public float minY = -7f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if(transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
