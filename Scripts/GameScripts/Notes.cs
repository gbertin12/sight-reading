using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private float speed;
    private MethodTest mt;
    // Start is called before the first frame update
    void Start()
    {
        speed = NoteSpawner.speed;
        mt = GameObject.Find("Notes").GetComponent<MethodTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NoteSpawnerOneHand.speedOneHand != 0)
        {
            speed = NoteSpawnerOneHand.speedOneHand;
        }
        else if (NoteSpawnerTwoHand.speedOneHand != 0)
        {
            speed = NoteSpawnerTwoHand.speedOneHand;
        }

        if (!mt.isPauseOn)
        {
            if (gameObject.tag == "Note") transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger On");

        if (other.gameObject.tag == "Note")
        {
            //other.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            //other.gameObject.GetComponent<Renderer>().material.SetColor("_color", Color.red);


            mt.ToogleIsPause();
        }
    }
}
