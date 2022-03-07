using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrière : MonoBehaviour
{
    public GameObject partition;
    public void MouvementArriere()
    {
        partition.transform.position += Vector3.left * -5;
    }
    public void MouvementAvant()
    {
        partition.transform.position += Vector3.left * 5;
    }

    public void Reset()
    {
        partition.transform.position = new Vector3(-342.05f, 5.34f, -20.46445f);
    }
}
