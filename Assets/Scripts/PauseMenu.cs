using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseUI;
    private bool isPaused = false;


	void Start ()
    {
        PauseUI.SetActive(false);
	}
	
	
	void Update ()
    {
		if(Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;         //setts toime to zero, time is nothing
        }

        if(!isPaused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;  //back to normal time can make slo motion
        }
	}


    public void Resume()
    {
        isPaused = false;
    }

    public void StartOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel(2);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void RedoTutorial()
    {
        Application.LoadLevel(1);
    }
}
