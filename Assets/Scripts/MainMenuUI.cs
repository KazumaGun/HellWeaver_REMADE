using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainMenuUI : MonoBehaviour
{

    public void PlayTutorial()
    {
        Application.LoadLevel(2);
    }


    public void StartGame()
    {
        Application.LoadLevel(1);
    }



    public void Settings()
    {
        Application.LoadLevel(5);
    }



    public void Unloackables()
    {
        Application.LoadLevel(6);
    }



    public void QuitGame()
    {
        Application.Quit();
    }

}


