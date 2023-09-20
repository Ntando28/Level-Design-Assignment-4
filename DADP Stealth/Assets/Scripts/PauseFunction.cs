using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFunction : MonoBehaviour
{
    public GameObject PauseMenuScreen;

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenuScreen.SetActive(false);
    }
    public void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene("GameScene");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
