using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartitionController : MonoBehaviour
{
    public string folderName;

    public static int metronomValue = 60;
    #region parent
    public Transform parentPublic;
    public static Transform parent;
    #endregion
    #region sliderSpeedChanger
    public Transform sliderSpeedChangerPublic;
    public static Transform sliderSpeedChanger;
    #endregion

    public static List<Texture2D> images;

    private ImageScript imageScript = new ImageScript();
    private CreateImageScript createImage = new CreateImageScript();

    // Start is called before the first frame update
    void Start()
    {
        sliderSpeedChanger = sliderSpeedChangerPublic;
        parent = parentPublic;
        images = imageScript.getAllImages(folderName);
        createImage.PlaceImage(images[0]);
        CreateImageScript.countImage++;
    }
    private void Update()
    {
        //metronomValue = (int)metronomSlider.value;
        
    }
    public void ImageFullyInScreen()
    {
        if (CreateImageScript.countImage < images.Count)
        {
            createImage.PlaceImage(images[CreateImageScript.countImage]);
            int gap = 6;
            if (CreateImageScript.countImage >= gap)
            {
                Destroy(GameObject.Find("sequence" + (CreateImageScript.countImage - gap)));
            }

            CreateImageScript.countImage++;
        }
    }
}
