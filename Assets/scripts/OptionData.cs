using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Option_data
{
    public bool sound = true;
    public bool is_kor = true;

    public bool GetSoundIsTrue()
    {
        return (sound == true);
    }
    public bool GetKorIsTrue()
    {
        return (is_kor == true);
    }
    public void SetSound(bool _sound)
    {
        sound = _sound;
    }
    public void SetLanguage(bool _is_kor)
    {
        is_kor = _is_kor;
    }
    public void SetOption(bool _sound, bool _is_kor)
    {
        sound = _sound;
        is_kor = _is_kor;
    }
}

public class OptionData : MonoBehaviour
{
    public static Option_data g_optiondata = new Option_data();

    public static OptionData _option_instance;

    public static OptionData Option_Instance
    {
        get
        {
            if (_option_instance == null)
            {
                _option_instance = FindObjectOfType(typeof(OptionData)) as OptionData;
                if (_option_instance == null)
                {
                    Debug.LogError("there needs to be one active Global script");
                }
            }
            return _option_instance;
        }
    }

    void Awake()
    {
        var obj = FindObjectsOfType<OptionData>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadOptionData()
    {
        string optionfilePath = Application.persistentDataPath + "/optionData.json";
        try
        {
            //File.ReadAllText(Application.dataPath + "/optionData.json");
            if (File.Exists(optionfilePath))
            {
                string str_optiondata = File.ReadAllText(optionfilePath);
                g_optiondata = JsonUtility.FromJson<Option_data>(str_optiondata);
            }
            else
            {
                g_optiondata.SetOption(true, true);
                File.WriteAllText(optionfilePath, JsonUtility.ToJson(g_optiondata, true));
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
    }

    public void SaveOptionData(Option_data toSaveData)
    {
        string optionfilePath = Application.persistentDataPath + "/optionData.json";
        File.WriteAllText(optionfilePath, JsonUtility.ToJson(toSaveData, true));
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadOptionData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
