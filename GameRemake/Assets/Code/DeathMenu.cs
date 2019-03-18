using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public string mainMenu;

    //restart the game play instead of going to main menue
    public void RestartGame()
    {
        //finds the Reset() inside of gamemanager script and resets game
        FindObjectOfType<GameManager>().Reset();

    }

    //let player go to main menu
    public void QuitToGame()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
