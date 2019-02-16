using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//we need to know what our player is in order to find our player
public class CameraController: MonoBehaviour
{
    /// <summary>
    /// we need to know what our player is in order to find our player
    /// then we will have the camera follow the player as he runs.
    /// that is the point of this code
    /// </summary>
    
    public PlayerControl thePlayer;
    private Vector3 lastPlayerPosition;
    private float distanceMoved;
    

    // Use this for initialization
    void Start ()
    {
        thePlayer = FindObjectOfType<PlayerControl>();
        lastPlayerPosition = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        distanceMoved = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceMoved, transform.position.y, transform.position.z);

       lastPlayerPosition = thePlayer.transform.position;

       

    }
}
