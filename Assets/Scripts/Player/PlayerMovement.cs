using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    private int touching = 0;
    private float dirX;

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
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, dirX * touching);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("rock"))
        {
            touching = 1;

        } else if(collision.gameObject.CompareTag("floor")) {
            GetComponent<PlayerBehaviour>().gameController.Restart();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {
            touching = 0;
        }
    }
}
