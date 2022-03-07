using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slid;
    public TextMeshProUGUI slidTxt;
    // Start is called before the first frame update
    void Start()
    {
        slid.onValueChanged.AddListener((value) =>
        {
            slidTxt.text = "" + Convert.ToInt16(slid.value);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
