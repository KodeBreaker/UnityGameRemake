using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathMenu;


	// Use this for initialization
	void Start ()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;//when dead/restarting , reset score to 0
        thePlayer.gameObject.SetActive(false);

        //turns on death menu scene
        theDeathMenu.gameObject.SetActive(true);


        //StartCoroutine("RestartGameCo");
    }

    //when player dies, he gets put onto the death menu
    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);//turns off death menu screen when player restarts game
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        //score increases from 0 after being reset back to 0
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    //not using IEnumerator RestartGameCo as we have now implemented main and death menues, so the code needs to be altered to fit
    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;//when dead/restarting , reset score to 0
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        //score increases from 0 after being reset to 0
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
