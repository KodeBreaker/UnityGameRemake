﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    private float speedIncreaseMilestoneStore;

    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public GameManager theGameManager;

    //private Collider2D myCollider;

    private Animator myAnimator;
    public AudioSource jumpSound;
    public AudioSource deathSound;

    private bool stoppedJumping;//become true when touching ground, false when not touching ground
    private bool canDoubleJump;


    // Use this for initialization
    void Start ()
    {

        myRigidbody = GetComponent<Rigidbody2D>();//getcomponent searches on object the script is attached to

        //myCollider = GetComponent<Collider2D>();//search for collider on player

        myAnimator = GetComponent<Animator>();//search for animator connected on player

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;

    }

    // Update is called once per frame
    void Update ()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        //speed up move speed after a certain distance is covered
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;

        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //jump once at a time
            if (grounded)
            {

                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play();//plays the jump sound effect when we jump
            }
            if(!grounded && canDoubleJump)
            {
                //player can double jump by tapping mouse again.(not same as jumping really high by holding mouse button down)
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
                jumpSound.Play();//plays the jump sound effect when we double jump


            }

        }

        //jump higher if you hold down mouse button
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
        {
            if(jumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        //stops player jumping while in mid air
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if(grounded)//resets jumptime counter when grounded
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        //restart game when player hits the killbox 
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();//plays death sound when we fall off and die
        }
    }
}
