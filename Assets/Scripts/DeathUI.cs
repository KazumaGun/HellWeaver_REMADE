using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathUI : MonoBehaviour
{
    public void Redo()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel(2);
    }

}
