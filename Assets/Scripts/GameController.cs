using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private int life = 3;

    private CameraShake cameraShake;

    private void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        cameraShake = FindObjectOfType<CameraShake>();
    }
    
    public void AddScore(int points) {
        score += points;
        print(score + " POINTS!");
    }

    public void Damage() {
        life--;
        if(life <= 0) {
            print("DEAD");
            Restart();
        } else {
            cameraShake.Shake(0.1f);
            Handheld.Vibrate();
        }
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
