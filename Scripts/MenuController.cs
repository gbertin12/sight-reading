using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Canvas menu;
    public Button button;
    public Button showButton;
    public AnimationClip clipShow;
    public AnimationClip clipClose;
    // Start is called before the first frame update
    void Start()
    {
        //menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu()
    {
        menu.GetComponent<Animation>().Play(clipShow.name);
        
        showButton.gameObject.SetActive(false);
    }

    public void CloseMenu()
    {
        menu.GetComponent<Animation>().Play(clipClose.name);
        button.gameObject.SetActive(true);
    }
}
