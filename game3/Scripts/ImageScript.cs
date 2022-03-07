using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ImageScript : MonoBehaviour
{
    private List<Texture2D> images = new List<Texture2D>();
    public static int maxImageWidth;
    public List<Texture2D> getAllImages(string folderName)
    {
        int countImage = 1;
        var folderPath = "Assets/Resources/Partitions/" + folderName + "/";

        while (LoadTextures(folderPath + countImage + ".png"))
        {
            Texture2D image = LoadTextures(folderPath + countImage + ".png");
            images.Add(image);
            if (image.width > maxImageWidth)
            {
                maxImageWidth = image.width;
            }
            countImage++;
        }

        return images;
    }

    public Texture2D LoadTextures(string filePath)
    {
        //Here we convert images (determined by the file path) to a texture2D
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }

        return tex;
    }
}
