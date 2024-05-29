using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool lockCurser;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if(lockCurser)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void LoadMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Cursor.lockState = CursorLockMode.None;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
