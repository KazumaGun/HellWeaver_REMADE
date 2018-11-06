using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulManager : MonoBehaviour
{
    public int souls;
    public Text soulsText;

    void Update()
    {
        soulsText.text = (" Lost Souls Collected :  " + souls);
    }

}
