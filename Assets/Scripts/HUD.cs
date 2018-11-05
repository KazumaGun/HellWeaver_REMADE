using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //DISPLAYING HEALTH\\
    public Sprite[] HealthSprites;

    public Image HealthUI;

    //FOR ACCESSING HEALTH\\
    private Hero hero;

	void Start ()
    {
        hero = GameObject.FindGameObjectWithTag("Hero").GetComponent<Hero>();

	}
	
	
	void Update ()
    {
        HealthUI.sprite = HealthSprites[hero.currentHealth];
	}
}
