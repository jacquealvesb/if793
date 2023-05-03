using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rb;
    private float dirX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            dirX = Input.GetAxis("Horizontal") * speed;
        }
        else
        {
            dirX = Input.acceleration.x * speed;
        }
        
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), transform.position.y);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, 0f);
    }
}
