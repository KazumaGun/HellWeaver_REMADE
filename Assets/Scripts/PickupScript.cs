using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    public enum PickupItem
    {
        SpeedBoost,
        WalkThroughBoost,
    
       
    }

    public PickupItem typeOfPickup;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject aCollisionObject = collision.gameObject;
        if (aCollisionObject.tag == "Hero")
        {
            switch (typeOfPickup)
            {
                case PickupItem.SpeedBoost:
                    StartCoroutine(aCollisionObject.GetComponent<Hero>().SpeedBoost());
                    break;
                case PickupItem.WalkThroughBoost:
                    StartCoroutine(aCollisionObject.GetComponent<Hero>().WalkThroughBoost());
                    break;
         
            }

            Destroy(gameObject);
        }


    }
}
