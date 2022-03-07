using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
    private int id;
    private string value;
    private string nameSettings;
    private string defaultValue;
    private string status;

    public Settings(int unId, string uneValue, string unNameSettings, string uneDefaultValue, string unStatus)
    {
        Id = unId;
        Value = uneValue;
        NameSettings = unNameSettings;
        DefaultValue = uneDefaultValue;
        Status = unStatus;
    }

    public int Id { get => id; set => id = value; }
    public string Value { get => value; set => this.value = value; }
    public string NameSettings { get => nameSettings; set => nameSettings = value; }
    public string DefaultValue { get => defaultValue; set => defaultValue = value; }
    public string Status { get => status; set => status = value; }
}
