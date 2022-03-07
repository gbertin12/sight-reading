using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{
    private double duration;
    private int midi;
    private double time;
    private int channel;
    private int ticks;
    private int mesure;

    public Note(double uneDuration, int unMidi, double unTime, int unChannel, int unTicks, int uneMesure)
    {
        Duration = uneDuration;
        Midi = unMidi;
        Time = unTime;
        Channel = unChannel;
        Ticks = unTicks;
        Mesure = uneMesure;
    }

    public double Duration { get => duration; set => duration = value; }
    public int Midi { get => midi; set => midi = value; }
    public double Time { get => time; set => time = value; }
    public int Channel { get => channel; set => channel = value; }
    public int Ticks { get => ticks; set => ticks = value; }
    public int Mesure { get => mesure; set => mesure = value; }
}
