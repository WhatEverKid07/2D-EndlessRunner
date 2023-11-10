using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int Scene;

    public void OpenScene()
    {
        SceneManager.LoadSceneAsync(Scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
