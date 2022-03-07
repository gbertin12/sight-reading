using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MethodTest : MonoBehaviour
{
    private List<int> notes = new List<int>();
    public bool isPauseOn;

    private void Start()
    {
        isPauseOn = false;
        
    }

    public void ToogleIsPause()
    {
        isPauseOn = !isPauseOn;

        if (isPauseOn)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    public void OnClicked(Button button)
    {
        notes.Add(Convert.ToInt16(button.name));
        print(button.name + " Liste des notes : " + notes);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("TriggerStay : " + other.name);
    }
}
