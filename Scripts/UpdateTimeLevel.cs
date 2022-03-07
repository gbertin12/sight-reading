using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpdateTimeLevel : MonoBehaviour
{
    private GstBDD gst = new GstBDD();

    public TextMeshProUGUI labelTime;
    public TMP_Dropdown dropdownTIme;


    // Update is called once per frame
    void Update()
    {
        if (labelTime.text == dropdownTIme.options[0].text)
        {
            gst.UpdateSetting("playTime", "2");
        }
        else if (labelTime.text == dropdownTIme.options[1].text)
        {
            gst.UpdateSetting("playTime", "4");
        }
        else if (labelTime.text == dropdownTIme.options[2].text)
        {
            gst.UpdateSetting("playTime", "6");
        }
        else if (labelTime.text == dropdownTIme.options[3].text)
        {
            gst.UpdateSetting("playTime", "full");
        }

    }
}
