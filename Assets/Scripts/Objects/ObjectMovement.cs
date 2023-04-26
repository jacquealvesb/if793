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
        if(transform.position.x < 0) {
            transform.position += Vector3.left * 0.1f * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.right * 0.1f * speed * Time.deltaTime;
        }

        float y = transform.position.y;
        float scale = 0.7f - 0.07f * y;
        transform.localScale = new Vector3(scale, scale, 0f);
    }

    private void FixedUpdate()
    {
        if(transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
