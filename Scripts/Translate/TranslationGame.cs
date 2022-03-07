using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using TMPro;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class TranslationGame : MonoBehaviour
{
    JsonReader jsonReader;
    private GstBDD db;
    private string langue;
    private string pathJson;
    public TextMeshProUGUI titre;
    public Text oneHanded;
    public Text twoHands;
    public Text partition;
    // Start is called before the first frame update
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
            pathJson = "Assets/Translate/FR/strings_fr_game.json";
        }
        if (langue == "en")
        {
            pathJson = "Assets/Translate/EN/strings_en_game.json";
        }
        if (langue == "es")
        {
            pathJson = "Assets/Translate/ES/strings_es_game.json";
        }
        return pathJson;
    }

    public void TranslateAll(string pathJson)
    {
        dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));
        titre.text = jsonFile["titre"];
        oneHanded.text = jsonFile["btnUneMain"];
        twoHands.text = jsonFile["btnDeuxMains"];
        partition.text = jsonFile["btnModePartition"];
    }
}
