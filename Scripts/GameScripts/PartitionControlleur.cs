using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PartitionControlleur : MonoBehaviour
{
    public float speed;
    public Slider slider;
    public Text txtMetro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtMetro.text = "Métronome : bug"; //+ Convert.ToInt16(slider.value);
        if (speed != 0)
        {
            //speed = slider.value / 180; //90 = 50

            transform.position += Vector3.left * speed * Time.deltaTime;
        }

    }

    public void Stop()
    {
        if(speed != 0)
        {
            speed = 0;
        }
        else
        {
           // speed = slider.value / 180; //90 = 50
        }
    }
}
