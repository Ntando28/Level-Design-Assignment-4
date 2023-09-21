using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //This activates the "Play"button's functionality
    public void Play()
    {
        Debug.Log("PlayClicked");
        SceneManager.LoadScene("GameScene");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Game");
    }

    //The game will end when the "Quit" button is pressed
    public void Quit()
    {
        Application.Quit();
    }
}
