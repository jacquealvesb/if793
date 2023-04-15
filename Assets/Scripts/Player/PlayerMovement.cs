using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;

    private int touching = 0;
    private float dirX;

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;
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
