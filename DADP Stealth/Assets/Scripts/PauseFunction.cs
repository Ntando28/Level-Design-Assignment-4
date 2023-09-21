using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PauseFunction : MonoBehaviour
{
    public GameObject PauseMenuScreen;
    public bool paused;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("MustPauseNow");
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            PauseMenuScreen.gameObject.SetActive(true);
            
        } else if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            PauseMenuScreen.gameObject.SetActive(false);
        }
    }
    
    public void playGame()
    {
        pauseGame();
    }

    public void restart()
    {
        SceneManager.LoadScene("room");
    }

    public void quit()
    {
        Application.Quit();
    }
}
