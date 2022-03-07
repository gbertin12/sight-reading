using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    #region public variable 
    public int destroyTime = 18;
    public float maxTime = 2;
    public GameObject Do; // 
    public GameObject Note; // 
    public GameObject minor; // 
    public GameObject major; // 
    public int Hand = 1;
    public float height = 2.003f;
    public int minRange = 1;
    public int maxRange = 2;
    public static float speed;
    public float speed2 = 2;
    public static List<NoteClass> notes = new List<NoteClass>();
    public int globalLevel;

    #endregion
    #region private variable
    private float timer = 0;
    private int RandomNote;
    private int RandomMinor = 0;
    private int RandomMajor = 0;
    private int alterationLevel;
    private int levelOfNumNote;
    private int numNote = 0; // Random.Range(1, 7);
    private List<int> intList = new List<int>();
    private int numberNotes;
    #endregion
    #region classes
    public class NoteClass
    {
        private int id;
        private GameObject goNote;
        public NoteClass(int unId, GameObject unGo)
        {
            id = unId;
            goNote = unGo;
        }

        public int Id { get => id; set => id = value; }
        public GameObject GoNote { get => goNote; set => goNote = value; }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        #region GlobalLevel
        if (globalLevel == 0) { levelOfNumNote = 1; alterationLevel = 0; }
        else if (globalLevel == 1) { levelOfNumNote = 2; alterationLevel = 0; }
        else if (globalLevel == 2) { levelOfNumNote = 3; alterationLevel = 0; }
        else if (globalLevel == 3) { levelOfNumNote = 2; alterationLevel = 1; }
        else if (globalLevel == 4) { levelOfNumNote = 3; alterationLevel = 1; }
        else if (globalLevel == 5) { levelOfNumNote = 4; alterationLevel = 1; }
        #endregion
        #region intList values
        if (alterationLevel != 0)
        {
            intList.Add(2);
            intList.Add(4);
            intList.Add(6);
            intList.Add(7);
            intList.Add(9);
            intList.Add(11);
            intList.Add(13);
        }
        else
        {
            intList.Add(1);
            intList.Add(2);
            intList.Add(3);
            intList.Add(4);
            intList.Add(5);
            intList.Add(6);
            intList.Add(7);
            intList.Add(8);
            intList.Add(9);
            intList.Add(10);
            intList.Add(11);
            intList.Add(12);
            intList.Add(13);
            intList.Add(14);
        }

        #endregion
        speed = speed2;
        numNote = Random.Range(0, intList.Count);
        if (alterationLevel == 1) RandomMinor = Random.Range(1, 8);
        else if (alterationLevel == 2)
        {
            RandomMinor = Random.Range(1, 8);
            RandomMajor = Random.Range(1, 8);
        }
        if (globalLevel == 0 || globalLevel == 1)
        {
            numberNotes = 40;
        }
        else if (globalLevel == 2 || globalLevel == 3)
        {
            numberNotes = 50;
        }
        else if (globalLevel == 4)
        {
            numberNotes = 70;
        }
        else if (globalLevel == 5)
        {
            numberNotes = 100;
        }

        #region Apparition of the minor
        if (RandomMinor != 0)
        {
            Debug.LogWarning(RandomMinor);
            GameObject GOminor;
            GOminor = Instantiate(minor); // C minor
            //GOminor.name = "minor";
            if (RandomMinor == 1) { GOminor.transform.position = transform.position + new Vector3(-16.19f, 2.003f, 0); GOminor.name = "minor Do"; } //Do
            if (RandomMinor == 2) { GOminor.transform.position = transform.position + new Vector3(-16.19f, 2.212f, 0); GOminor.name = "minor re"; }//Re
            if (RandomMinor == 3) { GOminor.transform.position = transform.position + new Vector3(-16.19f, 2.381f, 0); GOminor.name = "minor mi"; } //Mi
            if (RandomMinor == 4) { GOminor.transform.position = transform.position + new Vector3(-16.19f, 2.59f, 0); GOminor.name = "minor fa"; } //Fa
            if (RandomMinor == 5) { GOminor.transform.position = transform.position + new Vector3(-16.19f, 2.783f, 0); GOminor.name = "minor sol"; } // Sol
            if (RandomMinor == 6) { GOminor.transform.position = transform.position + new Vector3(-16.19f, 2.976f, 0); GOminor.name = "minor La"; }//La
            if (RandomMinor == 7) { GOminor.transform.position = transform.position + new Vector3(-16.19f, 3.169f, 0); GOminor.name = "minor Si"; } //Si
        }
        #endregion
        #region Apparition of the major
        if (RandomMajor != 0)
        {
            Debug.LogWarning(RandomMajor);
            GameObject GOmajor;
            GOmajor = Instantiate(major); // C minor
            //GOminor.name = "minor";
            if (RandomMajor == 1) { GOmajor.transform.position = transform.position + new Vector3(-16.19f, 2.003f, 0); GOmajor.name = "major Do"; } //Do
            if (RandomMajor == 2) { GOmajor.transform.position = transform.position + new Vector3(-16.19f, 2.212f, 0); GOmajor.name = "major re"; }//Re
            if (RandomMajor == 3) { GOmajor.transform.position = transform.position + new Vector3(-16.19f, 2.381f, 0); GOmajor.name = "major mi"; } //Mi
            if (RandomMajor == 4) { GOmajor.transform.position = transform.position + new Vector3(-16.19f, 2.59f, 0); GOmajor.name = "major fa"; } //Fa
            if (RandomMajor == 5) { GOmajor.transform.position = transform.position + new Vector3(-16.19f, 2.783f, 0); GOmajor.name = "major sol"; } // Sol
            if (RandomMajor == 6) { GOmajor.transform.position = transform.position + new Vector3(-16.19f, 2.976f, 0); GOmajor.name = "major La"; }//La
            if (RandomMajor == 7) { GOmajor.transform.position = transform.position + new Vector3(-16.19f, 3.169f, 0); GOmajor.name = "major Si"; } //Si
        }
        #endregion
        Debug.Log("Screen width : " + Screen.width + " Longueur de la liste : " + intList.Count + " Niveau global : " + globalLevel + ", niveau touche : " + levelOfNumNote);
        if (intList.Count < 7) Debug.LogWarning("Liste : " + intList[0] + ", " + intList[1] + ", " + intList[2] + ", " + intList[3] + ", " + intList[4] + ", " + intList[5] + ", " + intList[6] + ", " + intList[7] + ", " + intList[8] + ", " + intList[9] + ", " + intList[10] + ", " + intList[11] + ", " + intList[12] + ", " + intList[13] + ";");
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed2;
        #region debutIf
        if (Hand == 1)
        {
            // when timer is superior than maxTime, a note will appear depands of the value of numNote
            if (timer > maxTime) // Time between each notes : lvl 1 : 2 seconds / lvl 2 : 1.5s / lvl 3 : 1s / lvl 4 : 0.75s / lvl 5 : 0.5s
            {
                #region WhiteTouch
                if (intList[numNote] == 2)
                {
                    GameObject newNote;
                    if (RandomMinor == 1)
                    {
                        newNote = Instantiate(Do); //this will bring up a Do minor / C minor
                        newNote.name = "Do minor";
                        newNote.transform.position = transform.position + new Vector3(0, 2.003f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 1)
                    {
                        newNote = Instantiate(Do); //this will bring up a Do major / C major
                        newNote.name = "Do major";
                        newNote.transform.position = transform.position + new Vector3(0, 2.003f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Do); //this will bring up a Do / C 
                        newNote.name = "Do";
                        newNote.transform.position = transform.position + new Vector3(0, 2.003f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 4)
                {
                    GameObject newNote;
                    if (RandomMinor == 2)
                    {
                        newNote = Instantiate(Note); // this will bring up a Re minor / D minor
                        newNote.name = "Re minor";
                        newNote.transform.position = transform.position + new Vector3(0, 2.212f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 2)
                    {
                        newNote = Instantiate(Note); //this will bring up a Re major / D major
                        newNote.name = "Re major";
                        newNote.transform.position = transform.position + new Vector3(0, 2.212f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Re / D
                        newNote.name = "Re";
                        newNote.transform.position = transform.position + new Vector3(0, 2.212f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 6)
                {
                    GameObject newNote;
                    if (RandomMinor == 3)
                    {
                        newNote = Instantiate(Note); // this will bring up a Mi minor / E minor
                        newNote.name = "Mi minor";
                        newNote.transform.position = transform.position + new Vector3(0, 2.381f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 3)
                    {
                        newNote = Instantiate(Note); //this will bring up a Mi major / E major
                        newNote.name = "Mi major";
                        newNote.transform.position = transform.position + new Vector3(0, 2.381f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Mi / E 
                        newNote.name = "Mi";
                        newNote.transform.position = transform.position + new Vector3(0, 2.381f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 7)
                {
                    GameObject newNote;
                    if (RandomMinor == 4)
                    {
                        newNote = Instantiate(Note); // this will bring up a Fa minor / F minor
                        newNote.name = "Fa minor";
                        newNote.transform.position = transform.position + new Vector3(0, 2.59f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 4)
                    {
                        newNote = Instantiate(Note); //this will bring up a Fa major / F major
                        newNote.name = "Fa major";
                        newNote.transform.position = transform.position + new Vector3(0, 2.59f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Fa / F 
                        newNote.name = "Fa";
                        newNote.transform.position = transform.position + new Vector3(0, 2.59f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 9)
                {
                    GameObject newNote;
                    if (RandomMinor == 5)
                    {
                        newNote = Instantiate(Note); // this will bring up a Sol minor / G minor
                        newNote.name = "Sol minor";
                        newNote.transform.position = transform.position + new Vector3(0, 2.783f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 5)
                    {
                        newNote = Instantiate(Note); //this will bring up a Sol major / G major
                        newNote.name = "Sol major";
                        newNote.transform.position = transform.position + new Vector3(0, 2.783f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Sol / G
                        newNote.name = "Sol";
                        newNote.transform.position = transform.position + new Vector3(0, 2.783f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 11)
                {
                    GameObject newNote;
                    if (RandomMinor == 6)
                    {
                        newNote = Instantiate(Note); // this will bring up a La minor / A minor
                        newNote.name = "La minor";
                        newNote.transform.position = transform.position + new Vector3(0, 2.976f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 6)
                    {
                        newNote = Instantiate(Note); //this will bring up a La major / A major
                        newNote.name = "La major";
                        newNote.transform.position = transform.position + new Vector3(0, 2.976f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a La / A
                        newNote.name = "La";
                        newNote.transform.position = transform.position + new Vector3(0, 2.976f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 13)
                {
                    GameObject newNote;
                    if (RandomMinor == 7)
                    {
                        newNote = Instantiate(Note); // this will bring up a Si minor / B minor
                        newNote.name = "Si minor";
                        newNote.transform.position = transform.position + new Vector3(0, 3.169f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 7)
                    {
                        newNote = Instantiate(Note); //this will bring up a Si major / B major
                        newNote.name = "Si major";
                        newNote.transform.position = transform.position + new Vector3(0, 3.169f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Si / B
                        newNote.name = "Si";
                        newNote.transform.position = transform.position + new Vector3(0, 3.169f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                #endregion

            }
            timer += Time.deltaTime;
            // Conditions to be sure that the value of NumNote does not exceed the expected values and to modify the values of the range according to the level of NumNote chosen by the user

            if (numNote >= 7)
            {
                //numNote = Random.Range(numNote - 2, 8); //Range : lvl 1 : numNote - 2, 8 / lvl 2 : numNote - 3, 8 / lvl 3 : numNote - 4, 8
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 7); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 7); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 7); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 6)
            {
                //numNote = Random.Range(numNote - 2, 8); //Range : lvl 1 : numNote - 2, 8 / lvl 2 : numNote - 3, 8 / lvl 3 : numNote - 4, 8
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 7); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 7); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 7); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 2)
            {
                //numNote = Random.Range(numNote, 5); //Range : lvl 1 : numNote, 5 / lvl 2 : numNote - 1, 6 / lvl 3 : lvl 2 : numNote - 1, 7
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(0, 4); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 1, 6); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 1, 7); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 1)
            {
                //numNote = Random.Range(numNote, numNote + 3); //Range : lvl 1 : numNote, numNote + 3 / lvl 2 : numNote, numNote + 4 / lvl 3 : numNote, numNote + 5
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(0, 3); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(0, 5); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(0, 6); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote <= 0)
            {
                //numNote = Random.Range(1, 4);  //Range : lvl 1 :  1, 4 / lvl 2 : 1, 5 / lvl 3 : 1, 6
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(0, 4); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(0, 5); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(0, 6); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else
            {
                //numNote = Random.Range(numNote - 2, numNote + 2); //Range : lvl 1 : numNote - 2, numNote + 2 / lvl 2 : numNote - 2, numNote + 2 / lvl 3 : numNote - 2, numNote + 2
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, numNote + 2); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 2, numNote + 2); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 3, numNote + 2); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
        }
        #endregion finIf
        #region debutElse
        else
        {
            // when timer is superior than maxTime, a note will appear depands of the value of numNote
            if (timer > maxTime)
            {
                // Allows to display a note according to the value that NumNote will have
                if (numNote == 1)
                {
                    GameObject newNote = Instantiate(Do); //Do
                    newNote.name = "Do";
                    newNote.transform.position = transform.position + new Vector3(0, 1.4f, 0); //2003f
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);
                }
                else if (numNote == 2)
                {
                    GameObject newNote = Instantiate(Note); //Re
                    newNote.name = "Re";
                    newNote.transform.position = transform.position + new Vector3(0, 1.51f, 0);//2.216
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 3)
                {
                    GameObject newNote = Instantiate(Note); //Mi
                    newNote.name = "Mi";
                    newNote.transform.position = transform.position + new Vector3(0, 1.63f, 0);//2.381
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 4)
                {
                    GameObject newNote = Instantiate(Note); //Fa
                    newNote.name = "Fa";
                    newNote.transform.position = transform.position + new Vector3(0, 1.72f, 0);//2.59
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 5)
                {
                    GameObject newNote = Instantiate(Note); //Sol
                    newNote.name = "Sol";
                    newNote.transform.position = transform.position + new Vector3(0, 1.82f, 0);//2.783
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 6)
                {
                    GameObject newNote = Instantiate(Note);  //La
                    newNote.name = "La";
                    newNote.transform.position = transform.position + new Vector3(0, 1.92f, 0);//2.976
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 7)
                {
                    GameObject newNote = Instantiate(Note); //Si
                    newNote.name = "Si";
                    newNote.transform.position = transform.position + new Vector3(0, 2.03f, 0);//3.169
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 8)
                {
                    GameObject newNote = Instantiate(Do); //Si
                    newNote.name = "DoBas";
                    newNote.transform.position = transform.position + new Vector3(0, -0.36f, 0);
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 9)
                {
                    GameObject newNote = Instantiate(Note); //Si
                    newNote.name = "ReBas";
                    newNote.transform.position = transform.position + new Vector3(0, -0.23f, 0);
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 10)
                {
                    GameObject newNote = Instantiate(Note); //Mi
                    newNote.name = "MiBas";
                    newNote.transform.position = transform.position + new Vector3(0, -0.021f, 0);
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 11)
                {
                    GameObject newNote = Instantiate(Note); //Fa
                    newNote.name = "FaBas";
                    newNote.transform.position = transform.position + new Vector3(0, 0.167f, 0);
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 12)
                {
                    GameObject newNote = Instantiate(Note); //Sol
                    newNote.name = "SolBas";
                    newNote.transform.position = transform.position + new Vector3(0, 0.376f, 0);
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 13)
                {
                    GameObject newNote = Instantiate(Note);  //La
                    newNote.name = "LaBas";
                    newNote.transform.position = transform.position + new Vector3(0, 0.569f, 0);
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
                else if (numNote == 14)
                {
                    GameObject newNote = Instantiate(Note); //Si
                    newNote.name = "SiBas";
                    newNote.transform.position = transform.position + new Vector3(0, 0.762f, 0);
                    Destroy(newNote, destroyTime);
                    timer = 0;
                    AddNote(numNote, newNote);

                }
            }
            timer += Time.deltaTime;
            // Conditions to be sure that the value of NumNote does not exceed the expected values and to modify the values of the range according to the level of NumNote chosen by the user
            if (numNote >= 15)  // Range : lvl 1 : 13, 15 / lvl 2 : 12,15 / lvl 3 : 11, 15
            {
                //numNote = Random.Range(numNote - 4, numNote);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(13, 15); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(12, 15); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(11, 15); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote == 14) //Range : lvl 1 : numNote - 2, 15 / lvl 2 : numNote - 3, 15 / lvl 3 : numNote - 4, 15
            {
                // numNote = Random.Range(numNote - 4, 15);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 15); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 15); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 15); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote == 13) //Range : lvl 1 : numNote - 2, 15 / lvl 2 : numNote - 3, 15 / lvl 3 : numNote - 4, 15
            {
                //numNote = Random.Range(numNote - 4, 15);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 15); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 15); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 15); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote == 12) //Range : lvl 1 : numNote - 2, 15 / lvl 2 : numNote - 3, 15 / lvl 3 : numNote - 4, 15
            {
                //numNote = Random.Range(numNote - 4, 15);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 15); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 15); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 15); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote == 11) //Range : lvl 1 : numNote - 2, 15 / lvl 2 : numNote - 3, 15 / lvl 3 : numNote - 4, 15
            {
                //numNote = Random.Range(numNote - 4, 15);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 15); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 15); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 15); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote <= 0) //Range : lvl 1 : 1, 4 / lvl 2 : 1, 5 / lvl 3 : 1, 6
            {
                //numNote = Random.Range(1, 6);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(1, 4); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(1, 5); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(1, 6); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote == 1) //Range : lvl 1 : 1, 4 / lvl 2 : 1, 5 / lvl 3 : 1, 6
            {
                // numNote = Random.Range(1, 6);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(1, 4); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(1, 5); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(1, 6); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote == 2) //Range : lvl 1 : 1, 5 / lvl 2 : 1, 8 / lvl 3 : 1, 7
            {
                // numNote = Random.Range(1, 7);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(1, 5); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(1, 6); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(1, 7); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else if (numNote == 3) //Range : lvl 1 : 1, 6 / lvl 2 : 1, 7 / lvl 3 : 1, 8
            {
                // numNote = Random.Range(1, 8);
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(1, 6); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(1, 7); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(1, 8); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            else //Range : lvl 1 : numNote - 2, numNote + 3 / lvl 2 : numNote - 2, numNote + 4 / lvl 3 : numNote - 3, numNote + 5
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, numNote + 3); // level 1
                if (levelOfNumNote == 2) numNote = Random.Range(numNote - 2, numNote + 4); // level 2
                if (levelOfNumNote == 3) numNote = Random.Range(numNote - 3, numNote + 5); // level 3
                if (levelOfNumNote == 4) numNote = Random.Range(1, 15); // level 4
            }
            #endregion finElse
        }

    }
    public void AddNote(int id, GameObject unGo)
    {
        NoteClass note = new NoteClass(id, unGo);
        notes.Add(note);
    }
}