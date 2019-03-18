using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string mainMenu;
    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;//stop time in game when paused
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;//start time in game when unpaused
        pauseMenu.SetActive(false);
    }

    //restart the game play instead of going to main menue
    public void RestartGame()
    {
        Time.timeScale = 1f;//start time in game when game restarts
        pauseMenu.SetActive(false);
        //finds the Reset() inside of gamemanager script and resets game
        FindObjectOfType<GameManager>().Reset();

    }

    //let player go to main menu
    public void QuitToGame()
    {
        Time.timeScale = 1f;//time starts when loading main menu
        SceneManager.LoadScene(mainMenu);
    }
}
