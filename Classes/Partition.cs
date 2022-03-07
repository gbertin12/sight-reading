using UnityEngine;
using System.Collections;

public class Partition : MonoBehaviour
{
    private int id;
    private string compositor;
    private string workName;
    private int level;
    private string pathMp3File;
    private int ticksPerMesure;
    private double totalTime;
    private int nbMesures;
    private int nbNotes;
    private double pourcentFlat;
    private int centroid;
    private string pathPartitionFile;

    public Partition(int unId, string unCompositor, string unWorkName, int unLevel, string unPathMp3, int unTicksPerMesure,
                     double unTotalTime, int unNbMesures, int unNbNotes, double unPourcentFlat, int unCentroid, string unPathPartition)
    {
        Id = unId;
        Compositor = unCompositor;
        WorkName = unWorkName;
        Level = unLevel;
        PathMp3File = unPathMp3;
        ticksPerMesure = unTicksPerMesure;
        TotalTime = unTotalTime;
        NbMesures = unNbMesures;
        NbNotes = unNbNotes;
        PourcentFlat = unPourcentFlat;
        Centroid = unCentroid;
        PathPartitionFile = unPathPartition;

    }

    public int Id { get => id; set => id = value; }
    public string Compositor { get => compositor; set => compositor = value; }
    public string WorkName { get => workName; set => workName = value; }
    public int Level { get => level; set => level = value; }
    public string PathMp3File { get => pathMp3File; set => pathMp3File = value; }
    public int TicksPerMesure { get => ticksPerMesure; set => ticksPerMesure = value; }
    public double TotalTime { get => totalTime; set => totalTime = value; }
    public int NbMesures { get => nbMesures; set => nbMesures = value; }
    public int NbNotes { get => nbNotes; set => nbNotes = value; }
    public double PourcentFlat { get => pourcentFlat; set => pourcentFlat = value; }
    public int Centroid { get => centroid; set => centroid = value; }
    public string PathPartitionFile { get => pathPartitionFile; set => pathPartitionFile = value; }
}
