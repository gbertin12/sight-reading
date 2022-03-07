using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoteSpawnerTwoHand : MonoBehaviour
{
    #region public variable
    public int destroyTime = 18;
    public float maxTime = 2;
    public GameObject Do; // 
    public GameObject Note; // 
    public GameObject minor; // 
    public GameObject major; // 
    public static float speedOneHand;
    public float speed2 = 2;
    public string keyHelperValue;
    public static string KeyHelper;
    public static int twoHands;
    public static List<NoteSpawner.NoteClass> notes = new List<NoteSpawner.NoteClass>();

    //public static List<NoteSpawner.NoteClass> notes = new List<NoteSpawner.NoteClass>();
    private int globalLevel;
    #region GameObject Lines
    public GameObject lineDoUp;
    public GameObject lineReUp;
    public GameObject lineMiUp;
    public GameObject lineFaUp;
    public GameObject lineSolUp;
    public GameObject lineLaUp;
    public GameObject lineSiUp;
    public GameObject lineDoDown;
    public GameObject lineReDown;
    public GameObject lineMiDown;
    public GameObject lineFaDown;
    public GameObject lineSolDown;
    public GameObject lineLaDown;
    public GameObject lineSiDown;
    #endregion
    #endregion
    #region private variable
    private float timer;
    private int RandomNote;
    private int RandomMinor = 0;
    private int numberMinor = 0;
    private int numberMajor = 0;
    private int RandomMajor = 0;
    private int alterationLevel;
    private int levelOfNumNote;
    private int numNote = 0; // Random.Range(1, 7);
    private List<int> intList = new List<int>();
    private MethodTest mt;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        twoHands = 1;
        KeyHelper = keyHelperValue;
        alterationLevel = Random.Range(1, 3);
        mt = new MethodTest();
        timer = 0;
        globalLevel = TranslationTwoHands.level;
        Debug.Log("level : " + globalLevel);
        #region GlobalLevel
        if (globalLevel == 0) { levelOfNumNote = 1; numberMajor = 0; numberMinor = 0; }
        else if (globalLevel == 1) { levelOfNumNote = 1; numberMinor = 0; numberMajor = 0; }
        else if (globalLevel == 2) { levelOfNumNote = 2; numberMinor = 0; numberMajor = 0; }
        else if (globalLevel == 3) { levelOfNumNote = 2; if(alterationLevel == 1) numberMajor = 1; else numberMinor = 1; }
        else if (globalLevel == 4) { levelOfNumNote = 3; if (alterationLevel == 1) numberMajor = 1; else numberMinor = 1; }
        else if (globalLevel == 5) { levelOfNumNote = 4; if (alterationLevel == 1) numberMajor = 2; else numberMinor = 2; }
        #endregion
        #region intList values
        intList.Add(2); intList.Add(4); intList.Add(6); intList.Add(7); intList.Add(9);
        intList.Add(11); intList.Add(13);
        #endregion
        speedOneHand = speed2;
        numNote = Random.Range(0, intList.Count);
        #region Apparition of the minor

        GameObject GOminor;
        GameObject GOminor2;
        GOminor = Instantiate(minor);
        if (numberMinor == 1) { GOminor.transform.position = lineSiUp.transform.position + new Vector3(-6f, 0.270f, 0); GOminor.name = "minor Si"; } //Si
        else if (numberMinor == 2) {
            GOminor2 = Instantiate(minor);
            GOminor.transform.position = lineSiUp.transform.position + new Vector3(-6f, 0.10f, 0); GOminor.name = "minor Si"; 
            GOminor2.transform.position = lineMiUp.transform.position + new Vector3(-5.75f, 0.100f, 0); GOminor2.name = "minor mi"; } //Mi

        #endregion
        #region Apparition of the major

        GameObject GOmajor;
        GameObject GOmajor2;
        GOmajor = Instantiate(major);
        if (numberMajor == 1) { GOmajor.transform.position = lineFaUp.transform.position + new Vector3(-6f, 0.270f, 0); GOmajor.name = "major fa"; } //Si
        else if (numberMajor == 2) { 
            GOmajor.transform.position = lineFaUp.transform.position + new Vector3(-6f, 0.270f, 0); GOmajor.name = "major fa";
            GOmajor2 = Instantiate(major);
            GOmajor2.transform.position = lineDoUp.transform.position + new Vector3(-5.75f, 0.270f, 0); GOmajor2.name = "major Do"; } //Mi
        #endregion
        if (globalLevel == 0 || globalLevel == 1)
        {
            NoteSpawnerOneHand.numberNotes = 40;
        }
        else if (globalLevel == 2 || globalLevel == 3)
        {
            NoteSpawnerOneHand.numberNotes = 50;
        }
        else if (globalLevel == 4)
        {
            NoteSpawnerOneHand.numberNotes = 70;
        }
        else if (globalLevel == 5)
        {
            NoteSpawnerOneHand.numberNotes = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (NoteSpawner.notes.Count < NoteSpawnerOneHand.numberNotes)
        {
            if (Time.deltaTime == 0 && timer == 0)
            {
                mt.ToogleIsPause();
            }
            #region Algo
            // when timer is superior than maxTime, a note will appear depands of the value of numNote
            if (timer > maxTime)
            {
                #region White Notes
                // Allows to display a note according to the value that NumNote will have
                if (intList[numNote] == 2)
                {
                    RandomNote = Random.Range(1, 3);
                    GameObject newNote;
                    if (RandomMinor == 1)
                    {
                        if (RandomNote == 1)
                        {
                            newNote = Instantiate(Do); //this will bring up a Do / C 
                            newNote.name = "Do minor";
                            newNote.transform.position = lineDoUp.transform.position + new Vector3(7f, 0.270f, 0);
                        } // 1.3f
                        else
                        {
                            newNote = Instantiate(Note);
                            newNote.name = "DoDown minor";
                            newNote.transform.position = lineDoDown.transform.position + new Vector3(7f, 0.270f, 0); // -0.380f
                        }
                        AddNote(13, newNote);
                    }
                    else if (RandomMajor == 1)
                    {
                        if (RandomNote == 1)
                        {
                            newNote = Instantiate(Do); //this will bring up a Do / C 
                            newNote.name = "Do major";
                            newNote.transform.position = lineDoUp.transform.position + new Vector3(7f, 0.270f, 0);
                        } // 1.3f
                        else
                        {
                            newNote = Instantiate(Note);
                            newNote.name = "DoDown major";
                            newNote.transform.position = lineDoDown.transform.position + new Vector3(7f, 0.270f, 0); // -0.380f
                        }
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        if (RandomNote == 1)
                        {
                            newNote = Instantiate(Do); //this will bring up a Do / C 
                            newNote.name = "Do";
                            newNote.transform.position = lineDoUp.transform.position + new Vector3(7f, 0.270f, 0);
                        } // 1.3f
                        else
                        {
                            newNote = Instantiate(Note);
                            newNote.name = "DoDown";
                            newNote.transform.position = lineDoDown.transform.position + new Vector3(7f, 0.270f, 0); // -0.380f
                        }
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 4)
                {
                    RandomNote = Random.Range(1, 3);
                    GameObject newNote;
                    if (RandomMinor == 2)
                    {
                        newNote = Instantiate(Note); //Re
                        newNote.name = "Re";
                        if (RandomNote == 1) newNote.transform.position = lineReUp.transform.position + new Vector3(7f, 0.270f, 0); // 1.4f
                        else newNote.transform.position = lineReDown.transform.position + new Vector3(7f, 0.270f, 0);//2.216 - 0.29f

                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 2)
                    {
                        newNote = Instantiate(Note); //Re
                        newNote.name = "Re";
                        if (RandomNote == 1) newNote.transform.position = lineReUp.transform.position + new Vector3(7f, 0.270f, 0); // 1.4f
                        else newNote.transform.position = lineReDown.transform.position + new Vector3(7f, 0.270f, 0);//2.216 - 0.29f
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //Re
                        newNote.name = "Re";
                        if (RandomNote == 1) newNote.transform.position = lineReUp.transform.position + new Vector3(7f, 0.270f, 0); // 1.4f
                        else newNote.transform.position = lineReDown.transform.position + new Vector3(7f, 0.270f, 0);//2.216 - 0.29f
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 6)
                {
                    RandomNote = Random.Range(1, 3);
                    GameObject newNote;
                    if (RandomMinor == 3)
                    {
                        newNote = Instantiate(Note); //Mi
                        newNote.name = "Mi minor";
                        if (RandomNote == 1) newNote.transform.position = lineMiUp.transform.position + new Vector3(7f, 0.270f, 0);//2.59 1.46f
                        else newNote.transform.position = lineMiDown.transform.position + new Vector3(7f, 0.270f, 0);//2.59 - 0.230f

                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 3)
                    {
                        newNote = Instantiate(Note); //Mi
                        newNote.name = "Mi major";
                        if (RandomNote == 1) newNote.transform.position = lineMiUp.transform.position + new Vector3(7f, 0.270f, 0);//2.59 1.46f
                        else newNote.transform.position = lineMiDown.transform.position + new Vector3(7f, 0.270f, 0);//2.59 - 0.230f
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //Mi
                        newNote.name = "Mi";
                        if (RandomNote == 1) newNote.transform.position = lineMiUp.transform.position + new Vector3(7f, 0.270f, 0);//2.59 1.46f
                        else newNote.transform.position = lineMiDown.transform.position + new Vector3(7f, 0.270f, 0);//2.59 - 0.230f
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 7)
                {
                    RandomNote = Random.Range(1, 3);
                    GameObject newNote;
                    if (RandomMinor == 4)
                    {
                        newNote = Instantiate(Note); //Fa
                        newNote.name = "Fa minor";
                        if (RandomNote == 1) newNote.transform.position = lineFaUp.transform.position + new Vector3(7f, 0.270f, 0);//2.59 1.552f
                        else newNote.transform.position = lineFaDown.transform.position + new Vector3(7f, 0.270f, 0);//2.59 -0.130f

                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 4)
                    {
                        newNote = Instantiate(Note); //Fa
                        newNote.name = "Fa major";
                        if (RandomNote == 1) newNote.transform.position = lineFaUp.transform.position + new Vector3(7f, 0.270f, 0);//2.59 1.552f
                        else newNote.transform.position = lineFaDown.transform.position + new Vector3(7f, 0.270f, 0);//2.59 -0.130f
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //Fa
                        newNote.name = "Fa";
                        if (RandomNote == 1) newNote.transform.position = lineFaUp.transform.position + new Vector3(7f, 0.270f, 0);//2.59 1.552f
                        else newNote.transform.position = lineFaDown.transform.position + new Vector3(7f, 0.270f, 0);//2.59 -0.130f
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 9)
                {
                    RandomNote = Random.Range(1, 3);
                    GameObject newNote;
                    if (RandomMinor == 5)
                    {
                        newNote = Instantiate(Note);  //Sol minor
                        newNote.name = "Sol minor";
                        if (RandomNote == 1) newNote.transform.position = lineSolUp.transform.position + new Vector3(7f, 0.270f, 0);//2.976 1.649f
                        else newNote.transform.position = lineSolDown.transform.position + new Vector3(7f, 0.270f, 0);//2.976 -0.04f

                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 5)
                    {
                        newNote = Instantiate(Note);  //Sol major
                        newNote.name = "Sol major";
                        if (RandomNote == 1) newNote.transform.position = lineSolUp.transform.position + new Vector3(7f, 0.270f, 0);//2.976 1.649f
                        else newNote.transform.position = lineSolDown.transform.position + new Vector3(7f, 0.270f, 0);//2.976 -0.04f
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note);  //Sol
                        newNote.name = "Sol";
                        if (RandomNote == 1) newNote.transform.position = lineSolUp.transform.position + new Vector3(7f, 0.270f, 0);//2.976 1.649f
                        else newNote.transform.position = lineSolDown.transform.position + new Vector3(7f, 0.270f, 0);//2.976 -0.04f
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 11)
                {
                    RandomNote = Random.Range(1, 3);
                    GameObject newNote;
                    if (RandomMinor == 6)
                    {
                        newNote = Instantiate(Note);  //La
                        newNote.name = "La";
                        if (RandomNote == 1) newNote.transform.position = lineLaUp.transform.position + new Vector3(7f, 0.270f, 0);//2.976 1.737f
                        else newNote.transform.position = lineLaDown.transform.position + new Vector3(7f, 0.270f, 0);//2.976 0.06f

                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 6)
                    {
                        newNote = Instantiate(Note);  //La
                        newNote.name = "La";
                        if (RandomNote == 1) newNote.transform.position = lineLaUp.transform.position + new Vector3(7f, 0.270f, 0);//2.976 1.737f
                        else newNote.transform.position = lineLaDown.transform.position + new Vector3(7f, 0.270f, 0);//2.976 0.06f
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note);  //La
                        newNote.name = "La";
                        if (RandomNote == 1) newNote.transform.position = lineLaUp.transform.position + new Vector3(7f, 0.270f, 0);//2.976 1.737f
                        else newNote.transform.position = lineLaDown.transform.position + new Vector3(7f, 0.270f, 0);//2.976 0.06f
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 13)
                {
                    RandomNote = Random.Range(1, 3);
                    GameObject newNote;
                    if (RandomMinor == 7)
                    {
                        newNote = Instantiate(Note); //Si
                        newNote.name = "Si minor";
                        if (RandomNote == 1) newNote.transform.position = lineSiUp.transform.position + new Vector3(7f, 0.270f, 0);//3.169 1.839f
                        else newNote.transform.position = lineSiDown.transform.position + new Vector3(7f, 0.270f, 0);//3.169 0.16f

                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 7)
                    {
                        newNote = Instantiate(Note); //Si
                        newNote.name = "Si major";
                        if (RandomNote == 1) newNote.transform.position = lineSiUp.transform.position + new Vector3(7f, 0.270f, 0);//3.169 1.839f
                        else newNote.transform.position = lineSiDown.transform.position + new Vector3(7f, 0.270f, 0);//3.169 0.16f
                        AddNote(2, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //Si
                        newNote.name = "Si";
                        if (RandomNote == 1) newNote.transform.position = lineSiUp.transform.position + new Vector3(7f, 0.270f, 0);//3.169 1.839f
                        else newNote.transform.position = lineSiDown.transform.position + new Vector3(7f, 0.270f, 0);//3.169 0.16f
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
                Debug.LogError("numnote supérieur à 7 : " + numNote);
                //numNote = Random.Range(numNote - 2, 8); //Range : lvl 1 : numNote - 2, 8 / lvl 2 : numNote - 3, 8 / lvl 3 : numNote - 4, 8
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 7); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 7); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 7); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 6)
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 7); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 7); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 7); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 5)
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, 6); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 3, 7); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 4, 7); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 3)
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 1, 5); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 2, 5); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 2, 6); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 2)
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(0, 4); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 1, 6); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 1, 7); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 1)
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(0, 3); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(0, 5); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(0, 6); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else if (numNote == 0)
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(0, 4); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(0, 5); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(0, 6); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }
            else
            {
                // Change NumNote range depending on level
                if (levelOfNumNote == 1) numNote = Random.Range(numNote - 2, numNote + 2); // level 1
                else if (levelOfNumNote == 2) numNote = Random.Range(numNote - 2, numNote + 2); // level 2
                else if (levelOfNumNote == 3) numNote = Random.Range(numNote - 3, numNote + 3); // level 3
                else if (levelOfNumNote == 4) numNote = Random.Range(0, 7); // level 4
            }

            #endregion Algo
        }
    }
    public void AddNote(int id, GameObject unGo)
    {
        NoteSpawner.NoteClass note = new NoteSpawner.NoteClass(id, unGo);
        notes.Add(note);
    }
}