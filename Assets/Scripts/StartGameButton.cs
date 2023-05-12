using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{

    public int gameStartScene;
    public GameObject pauseMenu;

    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(gameStartScene);
        Time.timeScale = 0;
    }
}
