using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;

public class TestNoteBDD : MonoBehaviour
{
    private GstBDD gst = new GstBDD();
    private List<Note> notes = new List<Note>();
    private int indice;

    public Text txtScore;
    public Text txtValue;
    public Slider slider;
    private float timer;
        public GameObject statusBox;
    public GameObject statusBox2;

    private float speed = 1 / 2;


    // Start is called before the first frame update
    void Start()
    {

        notes = gst.GetNotesByIdPartitions(1);
        //foreach(Note n in notes)
        //{
        //    Debug.Log(n.Midi);
        //}
        Debug.Log(notes[0].Midi);
    }

    void Update()
    {

        //timer += Time.deltaTime;
        speed = slider.value / 2;

        txtScore.text = slider.value.ToString();
        txtValue.text = speed.ToString();
    }



    public void PlusValue()
    {
        slider.value += 0.1f;
    }

    public void MoinsValue()
    {
        slider.value -= 0.1f;
    }
}
