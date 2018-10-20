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
    public bool isGrounded;
    public LayerMask whatIsGround;


	
	void Start ()
    {
        heroRigidbody = GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        heroRigidbody.velocity = new Vector2(heroSpeed, heroRigidbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            heroRigidbody.velocity = new Vector2(heroRigidbody.velocity.x, jumpForce);
        }
	}
}
