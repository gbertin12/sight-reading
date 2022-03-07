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

public class TranslationHomePage : MonoBehaviour
{
    JsonReader jsonReader;
    private GstBDD db;
    private string langue;
    private string pathJson;
    public TextMeshProUGUI titre;
    public Text jeux;
    public Text lecon;
    public Text metronome;
    public Text param;

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
            pathJson = "Assets/Translate/FR/strings_fr_home.json";
        }
        if (langue == "en")
        {
            pathJson = "Assets/Translate/EN/strings_en_home.json";
        }
        if (langue == "es")
        {
            pathJson = "Assets/Translate/ES/strings_es_home.json";
        }
        return pathJson;
    }

    public void TranslateAll(string pathJson)
    {
        dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));
        titre.text = jsonFile["titre"];
        jeux.text = jsonFile["jeux"];
        lecon.text = jsonFile["lecon"];
        metronome.text = jsonFile["metronome"];
        param.text = jsonFile["parametres"];
    }
}
