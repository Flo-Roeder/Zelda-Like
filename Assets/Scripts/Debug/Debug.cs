using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{

    private bool debugMode;
    public GameObject debugButtons;


    public void ToggleDebug()
    {
        debugMode = !debugMode;
    }

    private void Update()
    {
        if (debugMode)
        {
            debugButtons.SetActive(true);
        }
        else
        {
            debugButtons.SetActive(false);
        }
    }

}
