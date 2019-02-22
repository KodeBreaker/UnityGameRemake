using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();//getcomponent searches on object the script is attached to
 
        myCollider = GetComponent<Collider2D>();//search for collider on player

        myAnimator = GetComponent<Animator>();//search for animator connected on player


    }
	
	// Update is called once per frame
	void Update ()
    {
        //if colliders are touching then its true and grounded becomes true
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        //vector2 is an x and y value
        //y value unaffected, get value already stored in y instead.
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        //when space bar/mouse pressed player jumps
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {

                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);

            }
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);


    }
}
