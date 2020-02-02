using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
