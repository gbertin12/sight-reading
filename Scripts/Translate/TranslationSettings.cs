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

public class TranslationSettings : MonoBehaviour
{
    JsonReader jsonReader;
    private GstBDD db;
    private string langue;
    private string pathJson;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI general;
    public TextMeshProUGUI sound;
    public TMP_Dropdown language;
    public TextMeshProUGUI music;
    public TextMeshProUGUI musicalNotation;
    public TextMeshProUGUI noteHelper;
    public TextMeshProUGUI instrument;
    public TextMeshProUGUI confidential;
    public TextMeshProUGUI privatyPolicy;
    public static string selectedLanguage;
    public TextMeshProUGUI TMPLanguage;
    private string lastLanguage = "";

    void Start()
    {
        db = new GstBDD();
        langue = db.GetSetting("language");
        pathJson = GetPathTranslateJson(langue);
        TranslateAll(pathJson);
    }
    private void Update()
    {
        if(lastLanguage != TMPLanguage.text)
        {
            ChangeLanguage();
        }
        lastLanguage = TMPLanguage.text;
    }

    public string GetPathTranslateJson(string langue)
    {
        string pathJson = "";
        if (langue == "fr")
        {
            pathJson = "Assets/Translate/FR/strings_fr_settings.json";
        }
        if (langue == "en")
        {
            pathJson = "Assets/Translate/EN/strings_en_settings.json";
        }
        if (langue == "es")
        {
            pathJson = "Assets/Translate/ES/strings_es_settings.json";
        }
        return pathJson;
    }

    public void TranslateAll(string pathJson)
    {
        dynamic jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(pathJson));
        titre.text = jsonFile["titre"];
        general.text = jsonFile["general"];
        sound.text = jsonFile["son"];
        music.text = jsonFile["musique"];
        musicalNotation.text = jsonFile["notationMusicale"];
        noteHelper.text = jsonFile["notesAide"];
        instrument.text = jsonFile["instrument"];
        confidential.text = jsonFile["confidentiel"];
        privatyPolicy.text = jsonFile["politiqueDeConfidentialite"];

        //dropdown languages
        language.options[0].text = jsonFile["langage1"];
        language.options[1].text = jsonFile["langage2"];
        language.options[2].text = jsonFile["langage3"];
    }

    public void ChangeLanguage()
    {
        if (TMPLanguage.text == language.options[0].text)
        {
            TMPLanguage.text = "Francais";
            db.UpdateSetting("language", "fr");
        }
        else if (TMPLanguage.text == language.options[1].text)
        {
            TMPLanguage.text = "English";
            db.UpdateSetting("language", "en");
        }
        else if (TMPLanguage.text == language.options[2].text)
        {
            TMPLanguage.text = "Espanol";
            db.UpdateSetting("language", "es");
        }
        langue = db.GetSetting("language");
        pathJson = GetPathTranslateJson(langue);
        TranslateAll(pathJson);
    }

}