using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameController gameController;
    public GameObject shield;

    public int life = 3;
    public bool secured = false;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("collectable")) {
            gameController.AddScore(1);
            Destroy(collider.gameObject);

        } else if(collider.gameObject.CompareTag("shield")) {
            if(!secured) {
                secured = true;
                animator.SetTrigger("protect");
                shield.SetActive(true);
            }

            Destroy(collider.gameObject);

        } else if(collider.gameObject.CompareTag("obstacle")) {
            if(!secured) {
                print("OUCH!");
                animator.SetTrigger("damage");

                life--;
                if(life <= 0) {
                    print("DEAD");
                    gameController.Restart();
                }
            } else {
                secured = false;
                shield.SetActive(false);
            }
            
            Destroy(collider.gameObject);
        }
    }
}
