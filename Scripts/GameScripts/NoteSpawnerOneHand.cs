using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpawnerOneHand : MonoBehaviour
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
    //public static List<NoteSpawner.NoteClass> notes = new List<NoteSpawner.NoteClass>();
    private int globalLevel;
    public GameObject cube;
    public GameObject lineDo;
    public GameObject lineRe;
    public GameObject lineMi;
    public GameObject lineFa;
    public GameObject lineSol;
    public GameObject lineLa;
    public GameObject lineSi;
    public GameObject lineDoFa;
    public GameObject lineMiFa;
    public GameObject lineFaFa;
    public GameObject lineSolFa;
    public GameObject lineLaFa;
    public GameObject lineSiFa;
    public Canvas EndMenu;
    public GameObject TrebleKey;
    public GameObject BassKey;
    public static List<NoteSpawner.NoteClass> notes = new List<NoteSpawner.NoteClass>();
    #endregion
    #region private variable
    private float timer;
    private int RandomMinor = 0;
    private int RandomMajor = 0;
    private int alterationLevel;
    private int levelOfNumNote;
    private int numNote = 0; // Random.Range(1, 7);
    private List<int> intList = new List<int>();
    private MethodTest mt;
    public static int numberNotes;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if(TranslationOneHanded.key == 0)
        {
            TrebleKey.gameObject.SetActive(true);
            BassKey.gameObject.SetActive(false);

        }
        else
        {
            TrebleKey.gameObject.SetActive(false);
            BassKey.gameObject.SetActive(true);
        }
        NoteSpawnerTwoHand.twoHands = 0;
        mt = new MethodTest();
        timer = 0;
        globalLevel = TranslationOneHanded.level;
        Debug.Log("level : " + globalLevel);
        #region GlobalLevel
        if (globalLevel == 0) { levelOfNumNote = 1; alterationLevel = 0; }
        else if (globalLevel == 1) { levelOfNumNote = 1; alterationLevel = 0; }
        else if (globalLevel == 2) { levelOfNumNote = 2; alterationLevel = 0; }
        else if (globalLevel == 3) { levelOfNumNote = 2; alterationLevel = 1; }
        else if (globalLevel == 4) { levelOfNumNote = 3; alterationLevel = 1; }
        else if (globalLevel == 5) { levelOfNumNote = 4; alterationLevel = 2; }
        #endregion
        #region intList values
        intList.Add(2);
        intList.Add(4);
        intList.Add(6);
        intList.Add(7);
        intList.Add(9);
        intList.Add(11);
        intList.Add(13);
        #endregion
        speedOneHand = speed2;
        numNote = Random.Range(0, intList.Count);
        if (alterationLevel == 1) RandomMinor = Random.Range(1, 8);
        else if (alterationLevel == 2)
        {
            RandomMinor = Random.Range(1, 8);
            RandomMajor = Random.Range(1, 8);
        }
        #region Apparition of the minor
        if (RandomMinor != 0)
        {
            GameObject GOminor;
            GOminor = Instantiate(minor); // C minor
            //GOminor.name = "minor";
            if (RandomMinor == 1) { 
                if(TranslationOneHanded.key == 0) GOminor.transform.position = lineDo.transform.position + new Vector3(-5f, 0.2f, 0);
                else GOminor.transform.position = lineDoFa.transform.position + new Vector3(-5f, 0.2f, 0);
                GOminor.name = "minor Do";
            } //Do
            if (RandomMinor == 2) {
                if (TranslationOneHanded.key == 0) GOminor.transform.position = lineRe.transform.position + new Vector3(-5f, 0.2f, 0);
                else GOminor.transform.position = lineSi.transform.position + new Vector3(-5f, 0.2f, 0);
                GOminor.name = "minor Re";
            }//Re
            if (RandomMinor == 3) {
                if (TranslationOneHanded.key == 0) GOminor.transform.position = lineMi.transform.position + new Vector3(-5f, 0.2f, 0);
                else GOminor.transform.position = lineMiFa.transform.position + new Vector3(-5f, 0.2f, 0);
                GOminor.name = "minor Mi";
            } //Mi
            if (RandomMinor == 4) {
                if (TranslationOneHanded.key == 0) GOminor.transform.position = lineFa.transform.position + new Vector3(-5f, 0.2f, 0); 
                else GOminor.transform.position = lineFaFa.transform.position + new Vector3(-5f, 0.2f, 0); 
                GOminor.name = "minor Fa";
            } //Fa
            if (RandomMinor == 5) {
                if (TranslationOneHanded.key == 0) GOminor.transform.position = lineSol.transform.position + new Vector3(-5f, 0.2f, 0);
                else GOminor.transform.position = lineSolFa.transform.position + new Vector3(-5f, 0.2f, 0); 
                GOminor.name = "minor Sol";
            } // Sol
            if (RandomMinor == 6) {
                if (TranslationOneHanded.key == 0) GOminor.transform.position = lineLa.transform.position + new Vector3(-5f, 0.2f, 0);
                else GOminor.transform.position = lineLaFa.transform.position + new Vector3(-5f, 0.2f, 0);
                GOminor.name = "minor La";
            }//La
            if (RandomMinor == 7) {
                if (TranslationOneHanded.key == 0) GOminor.transform.position = lineSi.transform.position + new Vector3(-5f, 0.2f, 0);
                else GOminor.transform.position = lineSiFa.transform.position + new Vector3(-5f, 0.2f, 0);
                GOminor.name = "minor Si";
            } //Si
        }
        #endregion
        #region Apparition of the major
        if (RandomMajor != 0)
        {
            GameObject GOmajor;
            GOmajor = Instantiate(major); // C minor
            //GOminor.name = "minor";
            if (RandomMajor == 1) {
                if (TranslationOneHanded.key == 0) GOmajor.transform.position = lineDo.transform.position + new Vector3(-4.75f, 0, 0);
                else GOmajor.transform.position = lineDoFa.transform.position + new Vector3(-4.75f, 0, 0);
                GOmajor.name = "major Do"; } //Do
            if (RandomMajor == 2) {
                if (TranslationOneHanded.key == 0) GOmajor.transform.position = lineRe.transform.position + new Vector3(-4.75f, 0, 0);
                else GOmajor.transform.position = lineSi.transform.position + new Vector3(-4.75f, 0, 0);
                GOmajor.name = "major re"; }//Re
            if (RandomMajor == 3) {
                if (TranslationOneHanded.key == 0) GOmajor.transform.position = lineMi.transform.position + new Vector3(-4.75f, 0, 0);
                else GOmajor.transform.position = lineMiFa.transform.position + new Vector3(-4.75f, 0, 0);
                GOmajor.name = "major mi"; } //Mi
            if (RandomMajor == 4) {
                if (TranslationOneHanded.key == 0) GOmajor.transform.position = lineFa.transform.position + new Vector3(-4.75f, 0, 0);
                else GOmajor.transform.position = lineFaFa.transform.position + new Vector3(-4.75f, 0, 0);
                GOmajor.name = "major fa"; } //Fa
            if (RandomMajor == 5) {
                if (TranslationOneHanded.key == 0) GOmajor.transform.position = lineSol.transform.position + new Vector3(-4.75f, 0, 0);
                else GOmajor.transform.position = lineSolFa.transform.position + new Vector3(-4.75f, 0, 0);
                GOmajor.name = "major sol"; } // Sol
            if (RandomMajor == 6) {
                if (TranslationOneHanded.key == 0) GOmajor.transform.position = lineLa.transform.position + new Vector3(-4.75f, 0, 0);
                else GOmajor.transform.position = lineLaFa.transform.position + new Vector3(-4.75f, 0, 0);
                GOmajor.name = "major La"; }//La
            if (RandomMajor == 7) {
                if (TranslationOneHanded.key == 0) GOmajor.transform.position = lineSi.transform.position + new Vector3(-4.75f, 0, 0);
                else GOmajor.transform.position = lineSiFa.transform.position + new Vector3(-4.75f, 0, 0);
                GOmajor.name = "major Si"; } //Si
        }
        #endregion
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
    }
    // Update is called once per frame
    void Update()
    {

        if (Time.deltaTime == 0 && timer == 0)
        {
            mt.ToogleIsPause();
        }
        //StartCoroutine(ShowMenu());
        speedOneHand = speed2;
        if (notes.Count < numberNotes)
        {
            #region Algo
            if (timer == 0) timer += Time.deltaTime;
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
                        if(TranslationOneHanded.key == 0) newNote.transform.position = lineDo.transform.position + new Vector3(13f, 0.540f, 0); //2.003f
                        else newNote.transform.position = lineDoFa.transform.position + new Vector3(13f, 0.540f, 0); //2.003f
                        AddNote(13, newNote);
                    }
                    else if (RandomMajor == 1)
                    {
                        newNote = Instantiate(Do); //this will bring up a Do major / C major
                        newNote.name = "Do major";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineDo.transform.position + new Vector3(13f, 0.540f, 0); //2.003f
                        else newNote.transform.position = lineDoFa.transform.position + new Vector3(13f, 0.540f, 0); //2.003f                        
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Do); //this will bring up a Do / C 
                        newNote.name = "Do";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineDo.transform.position + new Vector3(13f, 0.540f, 0); //2.003f
                        else newNote.transform.position = lineDoFa.transform.position + new Vector3(13f, 0.540f, 0); //2.003f                        
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 4)
                {
                    GameObject newNote; //2.212f
                    if (RandomMinor == 2)
                    {
                        newNote = Instantiate(Note); // this will bring up a Re minor / D minor
                        newNote.name = "Re minor";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineRe.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSi.transform.position + new Vector3(13f, 0.540f, 0); //2.003f
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 2)
                    {
                        newNote = Instantiate(Note); //this will bring up a Re major / D major
                        newNote.name = "Re major";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineRe.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSi.transform.position + new Vector3(13f, 0.540f, 0); //2.003f
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Re / D
                        newNote.name = "Re";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineRe.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSi.transform.position + new Vector3(13f, 0.540f, 0); //2.003f
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;
                }
                else if (intList[numNote] == 6)
                {
                    GameObject newNote; //2.381f
                    if (RandomMinor == 3)
                    {
                        newNote = Instantiate(Note); // this will bring up a Mi minor / E minor
                        newNote.name = "Mi minor";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineMi.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineMiFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 3)
                    {
                        newNote = Instantiate(Note); //this will bring up a Mi major / E major
                        newNote.name = "Mi major";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineMi.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineMiFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Mi / E 
                        newNote.name = "Mi";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineMi.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineMiFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 7)
                {
                    GameObject newNote; // 2.59f
                    if (RandomMinor == 4)
                    {
                        newNote = Instantiate(Note); // this will bring up a Fa minor / F minor
                        newNote.name = "Fa minor";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineFa.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineFaFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 4)
                    {
                        newNote = Instantiate(Note); //this will bring up a Fa major / F major
                        newNote.name = "Fa major";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineFa.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineFaFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Fa / F 
                        newNote.name = "Fa";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineFa.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineFaFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 9)
                {
                    GameObject newNote; // 2.783f
                    if (RandomMinor == 5)
                    {
                        newNote = Instantiate(Note); // this will bring up a Sol minor / G minor
                        newNote.name = "Sol minor";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineSol.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSolFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 5)
                    {
                        newNote = Instantiate(Note); //this will bring up a Sol major / G major
                        newNote.name = "Sol major";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineSol.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSolFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Sol / G
                        newNote.name = "Sol";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineSol.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSolFa.transform.position + new Vector3(13f, 0.540f, 0); 
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 11)
                {
                    GameObject newNote; //2.976f
                    if (RandomMinor == 6)
                    {
                        newNote = Instantiate(Note); // this will bring up a La minor / A minor
                        newNote.name = "La minor";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineLa.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineLaFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 6)
                    {
                        newNote = Instantiate(Note); //this will bring up a La major / A major
                        newNote.name = "La major";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineLa.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineLaFa.transform.position + new Vector3(13f, 0.540f, 0);
                        AddNote(intList[numNote] + 1, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a La / A
                        newNote.name = "La";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineLa.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineLaFa.transform.position + new Vector3(13f, 0.540f, 0); 
                        AddNote(intList[numNote], newNote);
                    }
                    Destroy(newNote, destroyTime);
                    timer = 0;

                }
                else if (intList[numNote] == 13)
                {
                    GameObject newNote; //3.169f
                    if (RandomMinor == 7)
                    {
                        newNote = Instantiate(Note); // this will bring up a Si minor / B minor
                        newNote.name = "Si minor";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineSi.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSiFa.transform.position + new Vector3(13f, 0.540f, 0); AddNote(intList[numNote] - 1, newNote);
                    }
                    else if (RandomMajor == 7)
                    {
                        newNote = Instantiate(Note); //this will bring up a Si major / B major
                        newNote.name = "Si major";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineSi.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSiFa.transform.position + new Vector3(13f, 0.540f, 0); AddNote(intList[numNote] - 1, newNote);
                        AddNote(2, newNote);
                    }
                    else
                    {
                        newNote = Instantiate(Note); //this will bring up a Si / B
                        newNote.name = "Si";
                        if (TranslationOneHanded.key == 0) newNote.transform.position = lineSi.transform.position + new Vector3(13f, 0.540f, 0);
                        else newNote.transform.position = lineSiFa.transform.position + new Vector3(13f, 0.540f, 0); AddNote(intList[numNote] - 1, newNote);
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
            else if (numNote <= 0)
            {
                Debug.LogError("- 2 0");
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