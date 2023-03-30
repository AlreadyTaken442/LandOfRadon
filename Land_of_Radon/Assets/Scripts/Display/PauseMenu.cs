using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Eine statische Variable, die den Spielzustand speichert.
    public static bool gameIsPaused = false;

    // Eine Referenz auf das Pausemenü-GameObject.
    public GameObject pauseMenuUI;

    void Update()
    {
        // Überprüfe, ob die Escape-Taste gedrückt wurde.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Wenn das Spiel bereits pausiert ist, mache mit Resume() weiter.
            if (gameIsPaused)
            {
                Resume();
            }
            // Ansonsten pausiere das Spiel mit Pause().
            else
            {
                Pause();
            }
        }
    }

    // Eine Methode, um das Spiel fortzusetzen.
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    // Eine Methode, um das Spiel zu pausieren.
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Eine Methode, um das Spiel zu beenden.
    public void Exit()
    {
        Debug.Log("Application CLosed");
        Application.Quit();
    }

    // Eine Methode, um zum Hauptmenü zurückzukehren.
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
