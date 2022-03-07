using UnityEngine;
using System.Collections;

public class Images : MonoBehaviour
{
    private int id;
    private int idPartition;
    private string pathImage;
    private int position;

    public Images(int unId, int unIdPartition, string unPath, int unePosition)
    {
        Id = unId;
        IdPartition = unIdPartition;
        PathImage = unPath;
        Position = unePosition;
    }

    public int Id { get => id; set => id = value; }
    public int IdPartition { get => idPartition; set => idPartition = value; }
    public string PathImage { get => pathImage; set => pathImage = value; }
    public int Position { get => position; set => position = value; }
}

