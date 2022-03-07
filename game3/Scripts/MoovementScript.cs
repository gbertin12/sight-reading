using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoovementScript : MonoBehaviour
{
    private float ticsInTheMeasure = 1f;
    private float sixtySeconds = 60f;
    public static float imageWidth = Screen.width * 2;
    private PartitionController partitionController = new PartitionController();
    private float distanceToTravel;
    private static int imageNumber = 0;

    private void Update()
    {
        while (ticsInTheMeasure == 0 || distanceToTravel == 0)
        {
            ticsInTheMeasure = (float)GameManager.lstPartition.TicksPerMesure;
            distanceToTravel = PartitionController.parent.position.x - PartitionController.sliderSpeedChanger.position.x;
        }
        //PartitionController.metronomeValue/sixtySeconds = metronome tics per seconds
        //ticsInTheMeasure/(PartitionController.metronomValue/sixtySeconds) = number of seconds that is needed to play all the tics
        //(2/3*Screen.width) = takes 2/3 of the screen width
        //(2/3*Screen.width)/(ticsInTheMeasure/(PartitionController.metronomValue/sixtySeconds))) = pixels needed to travel to correspond to all the tics
        //(screenWidth/Screen.width) = % diff between Screen width and image width (if the image is slower it will go slower)

        if (imageWidth == Screen.width * 2)
        {
            gameObject.transform.position += Vector3.left * (distanceToTravel / 3) * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position += (Vector3.left * (imageWidth / (ticsInTheMeasure * (PartitionController.metronomValue / sixtySeconds)))) * Time.deltaTime;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "LineTriggerSpawn")
        {
            partitionController.ImageFullyInScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "LineTriggerSpeedChanger")
        {
            imageNumber++;
            SetNextImageWidth(PartitionController.images[imageNumber]);
        }
    }

    public void SetNextImageWidth(Texture2D tex)
    {
        imageWidth = tex.width;
    }

}