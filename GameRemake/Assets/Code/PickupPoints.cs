using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoints : MonoBehaviour {

    public int scoreToGive;
    private ScoreManager theScoreManager;

    private AudioSource coinSound;

	// Use this for initialization
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();

        coinSound = GameObject.Find("coins sound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if coin tocuhes player it adds points to score
        if(other.gameObject.name == "Player")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);//deactivates coin so it wont stay after being collected

            if(coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
            {
                coinSound.Play();
            }
            coinSound.Play();//plays sound when we collect coin
        }
    }
}
