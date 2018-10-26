using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Hero theHero;
    private Vector3 lastHeroPos;
    private float distanceToMove;

	// Use this for initialization
	void Start ()
    {
        theHero = FindObjectOfType<Hero>();
        lastHeroPos = theHero.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceToMove = theHero.transform.position.x - lastHeroPos.x;
        transform.position = new Vector3(transform.position.x + distanceToMove , transform.position.y , transform.position.z);
        lastHeroPos = theHero.transform.position;
	}
}
