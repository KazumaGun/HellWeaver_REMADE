using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBossController : MonoBehaviour
{
    public Rigidbody2D heroRigidBody;
    public float jumpForce;

	// Use this for initialization
	void Start ()
    {
        heroRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       
            // Make sure the hero stays in the screen (put this at the end of the update method).
            // Remember, you can find out how far your hero can go in the Unity Editor by moving the
            // hero to get the left/right x-coordinates (like -10 and 10) and the top/bottom y-coordinates
            // (like -5 and 5).

            Vector3 position;
            position = transform.position;

            // don't go too far to the left
            if (transform.position.x < -28.0f)
            {
                position.x = -28.0f;
            }

            // don't go too far to the right
            if (transform.position.x > 28.0f)
            {
                position.x = 28.0f;
            }

            // don't go too far up
            if (transform.position.y > 10.5f)
            {
                position.y = 10.5f;
            }

            // don't go too far down
            if (transform.position.y < -11.30f)
            {
                position.y = -11.30f;
            }

            transform.position = position;
    }

    public void Jump()
    {
        heroRigidBody.AddForce (new Vector2 (0, jumpForce) );
    }
    
}
