using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI lifeText;

    private int score = 0;
    private int life = 3;

    private CameraShake cameraShake;

    private void Start() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        cameraShake = FindObjectOfType<CameraShake>();
    }
    
    public void AddScore(int points) {
        score += points;
        scoreText.text = "pontos\n" + score;
    }

    public void Damage() {
        life--;
        lifeText.text = "vidas\n" + life;
        if(life <= 0) {
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
