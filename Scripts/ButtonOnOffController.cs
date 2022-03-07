using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOffController : MonoBehaviour
{
    public GameObject ButtonOn;
    public GameObject ButtonOff;
    private int situation;
    void Start()
    {
        situation = 1;
    }

    public GameObject isGameObjectOnOrOff(GameObject gameObject)
    {
        //Permet de retourner le GameObject qui n'est pas celui attach� entre le BoutonOn et le BoutonOff

        if (gameObject == ButtonOn)
        {
            return ButtonOff;
        }else if(gameObject == ButtonOff)
        {
            return ButtonOn;
        }
        return null;
    } 

    public void ButtonSetActiveOrInactive()
    {
        //Fonction qui active si l'�l�ment est d�sactiv� et d�sactive si l'�l�ment est activ�
        
        if (situation == 1)
        {
            ButtonOff.SetActive(true);
            ButtonOn.SetActive(false);
            situation = 2;
        }else if (situation == 2)
        {
            ButtonOff.SetActive(false);
            ButtonOn.SetActive(true);
            situation = 1;
        }


    }
}
