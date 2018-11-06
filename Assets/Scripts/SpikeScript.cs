using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private Hero hero;



	void Start ()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            hero.Damage(1); //Spike damages Hero here


            //StartCoroutine(hero.hitB(0.02f , 250 , hero.transform.position)); Used for hitback
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
