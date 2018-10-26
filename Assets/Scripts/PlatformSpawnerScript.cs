using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform PlatformSpawnPoint;
    public float disBetween;
    private float platformWidth;


    // Use this for initialization
    void Start ()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.x < PlatformSpawnPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + disBetween, transform.position.y, transform.position.z);
            Instantiate(thePlatform, transform.position, transform.rotation);
        }
	}
}
