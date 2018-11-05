using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public GameObject hero;

    public float maxTime;
    public float minSwipeDistance;

    float startTime;
    float endTime;

    Vector3 startPosition;
    Vector3 endPosition;

    float swipeDistance;
    float swipeTime;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPosition = touch.position;
            }

            else

            if(touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPosition = touch.position;

                swipeDistance = (endPosition - startPosition).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDistance)
                {
                    Swipe();
                   
                }
            }
        }
	}


    void Swipe()
    {
        Vector2 distance = endPosition - startPosition;
        if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y) )
        {
            Debug.Log("Horizontal Swipe");



            if(distance.x > 0 )
            {
                Debug.Log("Right Swipe");
            }

            if (distance.x < 0)
            {
                Debug.Log("Left Swipe");
            }
        }

        else

        if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y) )
            {
                Debug.Log("Vertical Swipe");



            if (distance.y > 0)
            {
                Debug.Log("Up Swipe");


                hero.GetComponent<HeroBossController>().Jump();
            }

            if (distance.y < 0)
            {
                Debug.Log("Down Swipe");
            }
        }
    }
}
