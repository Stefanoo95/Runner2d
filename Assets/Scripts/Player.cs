using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody2D rigidBody;
    public float speed; 
    public float jumpForce;
    
    public LayerMask ground;
    public LayerMask deadGround;
    
    private Collider2D playerCollider;
    private Animator animator;
    public AudioSource deathSound;
    public AudioSource jumpSound;

    public float mileStone;
    private float mileStoneCount;
    public float speedMultiplayer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        mileStoneCount = mileStone;

        
    }

    // Update is called once per frame
    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(playerCollider, deadGround);
        
        if(dead)
        {
            GameOver();
        }

        if(transform.position.x>mileStoneCount)
        {
            mileStoneCount += mileStone;
            speed = speed * speedMultiplayer;
            mileStone = mileStone * speedMultiplayer;
        }

        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                jumpSound.Play();
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            }
        }
        animator.SetBool("grounded", grounded);
    }

    void GameOver()
    {
        gameManager.GameOver();
    }
}
