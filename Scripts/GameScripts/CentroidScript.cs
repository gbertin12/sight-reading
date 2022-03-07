using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroidScript : MonoBehaviour
{
    public GameObject piano;
    private int speed = 800;
    private int centroid;
    private Partition partition;
    private GstBDD gst = new GstBDD();
    private int i = 0;

    private void Start()
    {
        Debug.Log("Start");
        
    }
    // Update is called once per frame
    void Update()
    {
        if (i == 100)
        {
            partition = gst.GetPartitionById(GameManager.partitionId);
            Debug.Log("centroid de la partition : " + partition.Centroid);
            centroid = partition.Centroid;
            Debug.Log(centroid);
        }
        i++;
        piano.gameObject.transform.position += new Vector3(speed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(centroid.ToString() == other.gameObject.transform.parent.name)
        {
            speed = 0;
        }
       
    }
}
