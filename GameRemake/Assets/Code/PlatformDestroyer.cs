using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
    public GameObject platformDestructionPoint;


    // Use this for initialization
    void Start ()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");//look for the game object platdestrpoint


    }
	
	// Update is called once per frame
	void Update ()
    {
        //destroy platforms behind the PlatformDestructionPoint
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);

        }

    }
}
