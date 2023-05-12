using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public GameController gameController;
    public GameObject shield;
    private PlayerMovement playerMovement;
    public bool secured = false;
    public int slowStack;
    public int speedupStack;

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
            if(playerMovement.speed > 6f){
                slowStack++;
                playerMovement.speed = playerMovement.speed - 1f;
                AnimateDestroy(collider.gameObject);
            }
            else{
                playerMovement.speed = playerMovement.speed - 2f;
                slowStack=0;
                AnimateDestroy(collider.gameObject);
                StartCoroutine(RemoveSlow());
            }

        }
        else if(collider.gameObject.CompareTag("speedup")) {
            playerMovement.speed = playerMovement.speed * 1.08f;
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
    

    }
    private IEnumerator RemoveSlow(){
        yield return new WaitForSeconds(2);
        playerMovement.speed = 10f;
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
