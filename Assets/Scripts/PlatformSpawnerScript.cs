using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform PlatformSpawnPoint;
    public float distanceBetween;
    [SerializeField] private float platformWidth;
    [SerializeField] private float platformWidthMod;

    //RANDOM DISTANCE BETWEEN PLATFORMS\\
    [SerializeField] public float distanceBetweenMin;
    [SerializeField] public float distanceBetweenMax;

   



    // Use this for initialization
    void Start()
    {
        platformWidth = (thePlatform.GetComponent<BoxCollider2D>().size.x * platformWidthMod);
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < PlatformSpawnPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

         

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);



            Instantiate (thePlatform, transform.position, transform.rotation);
        }
    }


}



