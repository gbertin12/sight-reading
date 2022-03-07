using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class TranslationOneHanded : MonoBehaviour
{
    JsonReader jsonReader;
    private GstBDD db;
    private string langue;
    private string pathJson;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI musique;
    public TMP_Dropdown clefSol;
    public TMP_Dropdown niveau;
    public Text score;
    public Text go;
    public TextMeshProUGUI libelleLevel;
    public TextMeshProUGUI libelleKey;
    public static int level;
    public static int key;

    void Start()
    {
        db = new GstBDD();
        langue = db.GetSetting("language");
        pathJson = GetPathTranslateJson(langue);
        TranslateAll(pathJson);
    }

    private void Update()
    {
        if(libelleLevel.text == niveau.options[0].text)
        {
            level = 1;
        }
        else if (libelleLevel.text == niveau.options[1].text)
        {
            level = 2;
        }
        else if (libelleLevel.text == niveau.options[2].text)
        {
            level = 3;
        }
        else if (libelleLevel.text == niveau.options[3].text)
        {
            level = 4;
        }
        else if (libelleLevel.text == niveau.options[4].text)
        {
            level = 5;
        }
        if(libelleKey.text == clefSol.options[0].text)
        {
            key = 0;//Treble Key
        }
        else
        {
            key = 1;//Bass key
        }
    }
    public string GetPathTranslateJson(string langue)
    {
        string pathJson="";
        if(langue == "fr")
        {
            pathJson = "Assets/Translate/FR/strings_fr_oneHanded.json";
        }
        if (langue == "en")
        {
            pathJson = "Assets/Translate/EN/strings_en_oneHanded.json";
        }
        if (langue == "es")
        {
            pathJson = "Assets/Translate/ES/strings_es_oneHanded.json";
        }
        return pathJson;
    }

    public void TranslateAll(string pathJson)
    {
        dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));
        titre.text = jsonFile["titre"];
        score.text = jsonFile["score"];
        go.text = jsonFile["go"];

        // dropdown for levels
        niveau.options[0].text = jsonFile["niveau1"];
        niveau.options[1].text = jsonFile["niveau2"];
        niveau.options[2].text = jsonFile["niveau3"];
        niveau.options[3].text = jsonFile["niveau4"];
        niveau.options[4].text = jsonFile["niveau5"];

        // dropdown for keys
        clefSol.options[0].text = jsonFile["clef_de_sol"];
        clefSol.options[1].text = jsonFile["clef_de_fa"];
    }
}
