using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameController gameController;
    public GameObject shield;
    private PlayerMovement playerMovement;
    public bool secured = false;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("collectable")) {
            gameController.AddScore(1);
            AnimateDestroy(collider.gameObject);

        } else if(collider.gameObject.CompareTag("shield")) {
            if(!secured) {
                secured = true;
                animator.SetTrigger("protect");
                shield.SetActive(true);
            }

            AnimateDestroy(collider.gameObject);
        }
        else if(collider.gameObject.CompareTag("slow")) {
            playerMovement.speed = playerMovement.speed * 0.8f;
            AnimateDestroy(collider.gameObject);
        }
        else if(collider.gameObject.CompareTag("speedup")) {
            playerMovement.speed = playerMovement.speed * 1.2f;
            AnimateDestroy(collider.gameObject);

        } else if(collider.gameObject.CompareTag("obstacle") || collider.gameObject.CompareTag("static-obstacle")) {
            if(!secured) {
                animator.SetTrigger("damage");
                gameController.Damage();
            } else {
                secured = false;
                shield.SetActive(false);
            }
            
            AnimateDestroy(collider.gameObject);
        }
    //     else if(collider.gameObject.CompareTag("static-obstacle")) {
    //         if(!secured) {
    //             print("OUCH!");
    //             animator.SetTrigger("damage");
    //             gameController.Damage();
    //         } else {
    //             secured = false;
    //             shield.SetActive(false);
    //         }
    //         Destroy(collider.gameObject);
            
    //     }

    }

    private void AnimateDestroy(GameObject obj) {
        ObjectMovement objMovement = obj.GetComponent<ObjectMovement>();
        if(objMovement == null) {
            Destroy(obj);
        } else {
            objMovement.AnimateDisappear();
        }
    }
}
