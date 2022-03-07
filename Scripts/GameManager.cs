using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    #region public variable
    public Text txtScore;
    public Transform parent;
    public Image img;
    public Canvas endMenu;
    public GameObject piano;
    public Camera mainCamera;
    public int idPartition;
    public static int partitionId;
    public GameObject MetronomeImage1;
    public GameObject MetronomeImage2;
    public AudioSource audios;
    public Text txtAccuracy;
    public Text txtPlayTime;
    public AudioSource MetronomeAudio;
    public float speed = 2 / 2;
    public static Partition lstPartition;
    #endregion

    #region private variable
    private int indice;
    private float score;
    private int nbTotalNote;
    private float nbRightNote;
    private List<NoteSpawner.NoteClass> notes = new List<NoteSpawner.NoteClass>();
    private MethodTest mt;
    private float height;
    private GstBDD gst = new GstBDD();
    private List<GameObject> pianoTouch = new List<GameObject>();
    private List<Note> lstNotes = new List<Note>();
    private List<Note> lstNotesPlayed = new List<Note>();
    private float timer;
    private int x = 0;
    private AudioClip test;
    private bool playSong = true;
    private float timerNow;
    private List<TemporyNote> lstTimerNotePlayed = new List<TemporyNote>();
    private int[] lstTempoScore = new int[3] { 0, 0, 0 };
    private bool hardMode = false;
    private GameObject notePlayedColor;
    private float playTime;
    private bool isActive = true;
    private AudioClip metronomeClip;
   
   
    private int nbErrors = 0;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //mt = GameObject.Find("Notes").GetComponent<MethodTest>();
        partitionId = idPartition;
        score = 0;
        timer = 0;
        metronomeClip = UpdateSoundMetronome();
        playTime = GetPlayTime();
        gst.UpdateSetting("second_instrument", "bastringue");
        StartCoroutine(UpdateTime());
        playTime += 1;
        for (int i = 0; i < 87; i++ )
        {
            pianoTouch.Add(piano.gameObject.transform.GetChild(i).gameObject);
        }
        foreach(GameObject go in pianoTouch)
        {
            GameObject goChild = new GameObject();
            goChild = go.gameObject.transform.GetChild(0).gameObject;
            goChild.AddComponent<CanvasGroup>().blocksRaycasts = false;
        }
        lstPartition = gst.GetPartitionById(idPartition);
        lstNotes = gst.GetNotesByIdPartitions(lstPartition.Id);
        height = transform.position.y + 15;
        indice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        StartCoroutine(StartMetronome());
        UpdateScore();
        // Display Menu at the end game
        StartCoroutine(ShowMenu());
        if (gst.GetSetting("general_music") == "Y")
            ActiveSound(true);
        else
            ActiveSound(false);
    }
    public void OnClicked(Button button)
    {
        if (NoteSpawnerOneHand.notes != null || NoteSpawnerTwoHand.notes != null)
        {
            List<NoteSpawner.NoteClass> notess = new List<NoteSpawner.NoteClass>();
            if (NoteSpawnerOneHand.notes.Count != 0)
            {
                notess = NoteSpawnerOneHand.notes;
            }
            else if (NoteSpawnerTwoHand.notes.Count != 0)
            {
                notess = NoteSpawnerTwoHand.notes;
            }
            if (Convert.ToInt32(button.name) == notess[indice].Id)
            {
                if (mt.isPauseOn)
                {
                    mt.ToogleIsPause();
                }               
                if (notess[indice].GoNote.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
                {
                    notess[indice].GoNote.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else if(notess[indice].GoNote.gameObject.GetComponent<SpriteRenderer>().color != Color.yellow || notess[indice].GoNote.gameObject.GetComponent<SpriteRenderer>().color != Color.red)
                {
                    notess[indice].GoNote.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    score += 1;
                    nbRightNote += 1;
                }
                notess[indice].GoNote.gameObject.GetComponent<BoxCollider>().enabled = false;
                Destroy(notess[indice].GoNote, 2);
                indice += 1;
                nbTotalNote += 1;
                notess[indice].GoNote.gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0.2f);
            }
            else
            {
                notess[indice].GoNote.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    IEnumerator ShowMenu()
    {
        if (indice == NoteSpawnerOneHand.numberNotes)
        {
            if(NoteSpawnerTwoHand.twoHands == 1)
                yield return new WaitForSeconds(24);
            else
                yield return new WaitForSeconds(2);
            endMenu.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            notes.Clear();
            mt.ToogleIsPause();
        }
    }

    public void ActiveSound(bool value)
    {
       mainCamera.GetComponent<AudioListener>().enabled = value;
    }

    IEnumerator StartMetronome()
    {
        if (MetronomeImage1.activeInHierarchy == true)
        {
            yield return new WaitForSeconds(speed);
            MetronomeImage1.gameObject.SetActive(false);
            MetronomeImage2.gameObject.SetActive(true);
            if (playSong == false)
            {
                foreach (Note uneNote in lstNotesPlayed)
                {
                    notePlayedColor = GameObject.Find(uneNote.Midi.ToString());
                    if(notePlayedColor.transform.parent.name == "ToucheNoir")
                    {
                        notePlayedColor.GetComponent<Image>().color = Color.black;
                    }
                    else
                    {
                        notePlayedColor.GetComponent<Image>().color = Color.white;
                    }
                }
                SelectedScoreMode();
                resetVariable();
                foreach(Note uneNote in lstNotesPlayed)
                {
                    notePlayedColor = GameObject.Find(uneNote.Midi.ToString());
                    notePlayedColor.GetComponent<Image>().color = Color.red;
                }
                playSong = true;
            }
            yield return new WaitForSeconds(speed);
        }
        else
        {
            yield return new WaitForSeconds(speed);
            MetronomeImage1.gameObject.SetActive(true);
            MetronomeImage2.gameObject.SetActive(false);
            if (playSong)
            {
                PlayRightNotes();
                timerNow = timer;
                playSong = false;
            }
            MetronomeAudio.PlayOneShot(metronomeClip);
            yield return new WaitForSeconds(speed);
        }
    }
    public void SelectedScoreMode()
    {
        if (hardMode)
            CalculateAdditionnalScoreHardMode();
        else
            CalculateAdditionnalScoreEasyMode();
    }
    public void PlayRightNotes()
    {
        string soundPath = "";
        string settingsSecondInstrument = gst.GetSetting("second_instrument");
        if (settingsSecondInstrument == "bastringue")
            soundPath = "Sound/bastringue/";
        else if (settingsSecondInstrument == "piano")
            soundPath = "Sound/piano/";

        foreach (Note uneNote in lstNotesPlayed)
        {
            test = Resources.Load(soundPath + uneNote.Midi) as AudioClip;
            audios.PlayOneShot(test);
        }
    }
    public void resetVariable()
    {
        Debug.Log("x = " + x);
        nbErrors = 0;
        lstNotesPlayed.Clear();
        lstTimerNotePlayed.Clear();
        lstNotesPlayed = GetNoteActualTick(lstNotes[x].Ticks);
    }

    public void OnClickedTest(Button button)
    {
        if (SearchNote(Convert.ToInt32(button.name)) && MetronomeImage1.activeInHierarchy == true)
        {
            lstTimerNotePlayed.Add(new TemporyNote(Convert.ToInt32(button.name), timer));
        }
        else if (MetronomeImage1.activeInHierarchy == false)
            if (hardMode)
                score--;
        else
            nbErrors++;
    }
    // Search Note by midi number in lstNotesPlayed List
    public bool SearchNote(int midi)
    {
        bool newNote;

        newNote = true;
        // Search if newNote is on lstNotesPlayed
        foreach (Note uneNote in lstNotesPlayed)
        {
            if (uneNote.Midi == midi)
            {
                // Search if newNote isn't in lstTimerNotePlayed so if he didn't play that good note
                foreach (TemporyNote secondNote in lstTimerNotePlayed)
                {
                    if (secondNote.Midi == midi)
                        newNote = false;
                }
                if (newNote)
                    return true;
            }
        }
        return false;
    }
    // get List of Note by tick number during specific tick in data base
    public List<Note> GetNoteActualTick(int tick)
    {
        List<Note> playedNotes = new List<Note>();
        while (lstNotes[x].Ticks == tick)
        {
            playedNotes.Add(lstNotes[x]);
            x++;
        }
        return playedNotes;
    }

    public void CalculateAdditionnalScoreHardMode()
    {
        int temporyScore = lstTimerNotePlayed.Count - nbErrors;

        if (temporyScore < 0)
            score += 0;
        else
            score += temporyScore;
    }

    public void CalculateAdditionnalScoreEasyMode()
    {
        score += lstTimerNotePlayed.Count;
    }

    public float MultiplacateScoreByTempo(float scoreAdd)
    {
        if (scoreAdd < 0)
            return scoreAdd;
        return scoreAdd;
        // peut etre multiplier si il est plus ou moins proche du tempo
    }

    // modifier les timer par rapport ? la vitesse du metronome
    public void UpdateTempoScore()
    {
        float diffTempo;

        diffTempo = 0;
        foreach (TemporyNote uneNote in lstTimerNotePlayed)
        {
            diffTempo = timerNow - uneNote.Timer;

            if (diffTempo > 0.1 && diffTempo < 0.1)
                lstTempoScore[2] += 1;
            else if (diffTempo > 0.3 && diffTempo < 0.3)
                lstTempoScore[1] += 1;
            else if (diffTempo > 0.5 && diffTempo < 0.5)
                lstTempoScore[0] += 1;
        }
    }

    public void UpdateScore()
    {
        txtScore.text = "Score : " + score;
        if (nbTotalNote != 0)
        {
            txtAccuracy.text = "Accuracy : " + Mathf.Round((nbRightNote / nbTotalNote) * 100) + " %";
        }
        else
        {
            txtAccuracy.text = "Accuracy : ";
        }
    }

    public float GetPlayTime()
    {
        if (gst.GetSetting("playTime") == "full")
            return 0;
        return (float)Convert.ToDouble(gst.GetSetting("playTime")) * 60;
    }

    IEnumerator UpdateTime()
    {
        while (playTime > 0)
        {
            playTime--;
            yield return new WaitForSeconds(1F);
            txtPlayTime.text = string.Format("{0:0}:{1:00}", Mathf.Floor(playTime / 60), playTime % 60);
        }
        if (playTime == 0)
        {
            txtPlayTime.text = "";
        }
    }

    public AudioClip UpdateSoundMetronome()
    {
        string pathMetronomeSound;
        AudioClip audio;

        pathMetronomeSound = "Sound/Metronome/SoundTick_" + gst.GetSetting("metronomeSound");
        audio = Resources.Load(pathMetronomeSound) as AudioClip;
        return audio;
    }
}