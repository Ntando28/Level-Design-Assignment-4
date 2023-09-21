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
    public GameObject everything;
    private bool paused;
    private bool gameStarted;

    public void Start()
    {
        paused = false;
        gameStarted = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pauseGame();
        }
    }

    public void pauseGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            PauseMenuScreen.gameObject.SetActive(true);
            
        } else if (paused)
        {
            Time.timeScale = 1;
            PauseMenuScreen.gameObject.SetActive(false);
        }
    }
    
    public void playGame()
    {
        if (!gameStarted)
        {
            everything.SetActive(true);
            PauseMenuScreen.gameObject.SetActive(false);
        }
        else
        {
            pauseGame();
        }
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
