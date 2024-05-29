using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    //public GameObject background;
    public static bool gameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        //background.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        //background.SetActive(true);
        gameIsPaused = true;
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Start Menu");
        Resume();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
    }
}