using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //HERO MOVEMENTS\\
    public float heroSpeed;
    public float jumpForce;

    private Rigidbody2D heroRigidbody;

    //CHECKING FOR GORUND\\
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //JUMPING\\
    private int doubleJump;
    public int doubleJumpValue;

    //SPRITE ANIMATIONS\\
    private Animator heroAnimator;


	
	void Start ()
    {
        //JMUPING AND MOVING\\
        doubleJump = doubleJumpValue;
        heroRigidbody = GetComponent<Rigidbody2D>();

        //SPRITE ANIMATOR\\
        heroAnimator = GetComponent<Animator>();
	}
	
	
	void FixedUpdate ()
    {
        heroRigidbody.velocity = new Vector2(heroSpeed, heroRigidbody.velocity.y); 

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        
    }

    void Update()
    {
        //CHECKING GROUND\\
        if(isGrounded == true)
        {
            doubleJump = doubleJumpValue;
        }
        //JUMPING\\
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && doubleJump > 0)
        {
            heroRigidbody.velocity = Vector2.up * jumpForce;
            doubleJump--;
        }
        else
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && doubleJump == 0 && isGrounded == true)
        {
            heroRigidbody.velocity = Vector2.up * jumpForce;
            
        }
        heroAnimator.SetFloat("Speed", heroRigidbody.velocity.x);
        heroAnimator.SetBool("Grounded", isGrounded);

    }
}
