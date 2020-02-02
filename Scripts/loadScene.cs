using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    private playerControl player;

    public void OnLevelWasLoaded(int level) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);

        Debug.Log("loading");
        if (level == 2)
        {
            Debug.Log("Enable Flying");
            player.EnableJumpOnFinalScene();
        }
    }
}
