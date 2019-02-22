using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;//lets us know if we need to generate platforms
    public float distanceBetween;//find the distance between platforms
    private float platformWidth; // know the width of our platform to remove the error of telefragging

    //how much gap there is between each platform
    public float distanceBetweenMin;
    public  float distanceBetweenMax;

	// Use this for initialization
	void Start ()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;//getting the platform width



    }
	
	// Update is called once per frame
	void Update ()
    {
        //if position of where we currently are is less than platform point then move generation point ahead
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x
            + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //instantiate creates copy of platform
            Instantiate(thePlatform, transform.position, transform.rotation);


        }
	}
}
