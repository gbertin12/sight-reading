using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperKey : MonoBehaviour
{
    private string helperKey;
    private GstBDD gst;
    // Start is called before the first frame update
    void Start()
    {
        gst = new GstBDD();
        helperKey = gst.GetSetting("helper_key");
        Debug.LogError("helper key : " + helperKey);
        if (helperKey == "N")
        {
            this.gameObject.transform.GetChild(0).gameObject.AddComponent<CanvasGroup>().blocksRaycasts = false;
            this.gameObject.GetComponentInChildren<Text>().text = "";
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.AddComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
