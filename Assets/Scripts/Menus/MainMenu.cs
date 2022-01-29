using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void StartGame()
    {
        // Load the scene with id 1
        SceneManager.LoadScene(1);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
