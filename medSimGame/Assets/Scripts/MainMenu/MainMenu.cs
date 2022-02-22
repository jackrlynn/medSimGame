using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Start()
    {
        Time.timeScale = 0;
    }

    public void startGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1); // Load in starting scene
    }

    public void quitGame()
    {
        Application.Quit(); // Quit game
    }
}
