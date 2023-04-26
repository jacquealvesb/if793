using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private float dirX, dirY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(SystemInfo.deviceType == DeviceType.Desktop)
        {
            dirX = Input.GetAxis("Horizontal") * speed;
            dirY = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            dirX = Input.acceleration.x * speed;
            dirY = Input.acceleration.y * speed;
        }
        
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2f, 2f), Mathf.Clamp(transform.position.y, -4f, 4f));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY * 1.2f);

        float y = transform.position.y;
        float scale = 0.4f - 0.04f * y;
        transform.localScale = new Vector3(scale, scale, 0f);
    }
}
