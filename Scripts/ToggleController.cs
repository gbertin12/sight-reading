using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public GameObject toggle;
    private GstBDD db;
    // Start is called before the first frame update
    void Start()
    {
        db = new GstBDD();
        if(toggle.name == "NoteHelper")
        {
            if (db.GetSetting("helper_key") == "Y")
            {
                gameObject.GetComponent<Toggle>().isOn = true;
            }
            else
            {
                gameObject.GetComponent<Toggle>().isOn = false;
            }
        }
        else if (toggle.name == "Sound")
        {
            if (db.GetSetting("general_music") == "Y")
            {
                gameObject.GetComponent<Toggle>().isOn = false;
            }
            else
            {
                gameObject.GetComponent<Toggle>().isOn = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.name == "NoteHelper")
        {
            if (gameObject.GetComponent<Toggle>().isOn == true)
            {
                db.UpdateSetting("helper_key", "Y");
            }
            else
            {
                db.UpdateSetting("helper_key", "N");
            }
        }
        else if (toggle.name == "Sound")
        {
            if (gameObject.GetComponent<Toggle>().isOn == true)
            {
                db.UpdateSetting("general_music", "N");
            }
            else
            {
                db.UpdateSetting("general_music", "Y");
            }
        }
 
    }
}
