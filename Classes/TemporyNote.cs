using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporyNote : MonoBehaviour
{
    private int midi;
    private float timer;

    public TemporyNote(int unMidi, float unTimer)
    {
        Midi = unMidi;
        Timer = unTimer;
    }

    public int Midi { get => midi; set => midi = value; }
    public float Timer { get => timer; set => timer = value; }
}
