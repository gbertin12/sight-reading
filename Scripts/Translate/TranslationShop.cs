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

public class TranslationShop : MonoBehaviour
{
    JsonReader jsonReader;
    private GstBDD db;
    private string langue;
    private string pathJson;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI bemols;
    public TextMeshProUGUI musique;
    public TMP_Dropdown niveau;
    public TextMeshProUGUI metronome;
    public Text score;
    public Text go;
    public TextMeshProUGUI libelleLevel;
    public static int level;

    void Start()
    {
        db = new GstBDD();
        langue = db.GetSetting("language");
        pathJson = GetPathTranslateJson(langue);
        TranslateAll(pathJson);
    }

    public string GetPathTranslateJson(string langue)
    {
        string pathJson = "";
        if (langue == "fr")
        {
            pathJson = "Assets/Translate/FR/strings_fr_twoHands.json";
        }
        if (langue == "en")
        {
            pathJson = "Assets/Translate/EN/strings_en_twoHands.json";
        }
        if (langue == "es")
        {
            pathJson = "Assets/Translate/ES/strings_es_twoHands.json";
        }
        return pathJson;
    }

    public void TranslateAll(string pathJson)
    {
        dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));
        titre.text = jsonFile["titre"];
        metronome.text = jsonFile["metronome"];
        score.text = jsonFile["score"];
        go.text = jsonFile["go"];

        // dropdown for levels
        niveau.options[0].text = jsonFile["niveau1"];
        niveau.options[1].text = jsonFile["niveau2"];
        niveau.options[2].text = jsonFile["niveau3"];
        niveau.options[3].text = jsonFile["niveau4"];
        niveau.options[4].text = jsonFile["niveau5"];
    }
}
