using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstationaryObjectMovement : MonoBehaviour
{
    public float speed = 1f;
    public float minY = -7f;

    private float initialScale;

    void Awake(){
        minY = Random.Range(-4f,2f);
    }

    void Start() {
        minY = Random.Range(-4f,2f);
        initialScale = transform.localScale.x;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if(transform.position.x < 0) {
            transform.position += Vector3.left * 0.1f * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.right * 0.1f * speed * Time.deltaTime;
        }

        float y = transform.position.y;
        float scale = initialScale - initialScale/10 * y;
        transform.localScale = new Vector3(scale, scale, 0f);
    }

    private void FixedUpdate()
    {
        if(transform.position.y < minY) {
            speed = 0f;
            // yield WaitForSeconds(3f);
        }
    }
}