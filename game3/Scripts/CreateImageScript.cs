using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateImageScript : MonoBehaviour
{
    
    public static int countImage = 0;
    
    public void PlaceImage(Texture2D image)
    {
        GameObject go = new GameObject("sequence" + countImage);
        go.AddComponent<Image>();
        go.GetComponent<Image>().preserveAspect = true;
        go.AddComponent<MoovementScript>();
        go.AddComponent<BoxCollider>();
        go.GetComponent<BoxCollider>().center = new Vector3(50, 0);
        go.GetComponent<BoxCollider>().size = new Vector3(100, 1);
        go.GetComponent<BoxCollider>().isTrigger = true;
        go.transform.SetParent(PartitionController.parent);
        go.GetComponent<Image>().sprite = Sprite.Create(image, new Rect(0.0f, 0.0f, image.width, image.height), new Vector2(0, 0), 100.0f);

        RectTransform uitransform = go.GetComponent<RectTransform>();
        uitransform.anchorMin = new Vector2(0, 0.5f);
        uitransform.anchorMax = new Vector2(0, 0.5f);
        uitransform.pivot = new Vector2(0, 0.5f);

        float imagePourcentageDiff =100-(((ImageScript.maxImageWidth - image.width) * 100) / ImageScript.maxImageWidth);
        go.transform.localScale = new Vector3(imagePourcentageDiff/100*5, (float)imagePourcentageDiff/100*5);
        go.transform.position = new Vector2(PartitionController.parent.position.x, PartitionController.parent.position.y);
    }
}
