using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestroyerPoint;
	
	void Start ()
    {
        platformDestroyerPoint = GameObject.Find("PlatformDestroyerPoint");
	}
	
	
	void Update ()
    {
		if(transform.position.x < platformDestroyerPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	}
}
