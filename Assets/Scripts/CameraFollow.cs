using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject Hero;


    //CAMERA BOUNDS\\
    public bool cameraBounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

	// Use this for initialization
	void Start ()
    {
        Hero = GameObject.FindGameObjectWithTag("Hero");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float positionX = Mathf.SmoothDamp(transform.position.x , Hero.transform.position.x , ref velocity.x, smoothTimeX);
        float positionY = Mathf.SmoothDamp(transform.position.y, Hero.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(positionX, positionY, transform.position.z);


        //CAMERA BOUNDS\\
        if (cameraBounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x) ,
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y) ,
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z) );
        }
    }
}
