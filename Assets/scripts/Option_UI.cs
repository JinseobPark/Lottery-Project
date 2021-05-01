using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class Option_data
{
    public bool sound = true;
    public bool is_kor = true;
}

[RequireComponent(typeof(Image))]
public class Option_UI : MonoBehaviour
{
    public static Option_data g_optiondata = new Option_data();
    public static Option_data cur_optiondata = new Option_data();

    public Sprite CheckImage;
    public Sprite UnCheckImage;
    public Sprite KoreanImage;
    public Sprite EnglishImage;

    public Image SoundCheckObjImage;
    public Image LanguageCheckObjImage;

    // Start is called before the first frame update
    void Start()
    {
        SoundCheckObjImage = GameObject.Find("SoundButton").GetComponent<Image>();
        LanguageCheckObjImage = GameObject.Find("LanguageButton").GetComponent<Image>();
        LoadOptionData();
        CopyOption();
    }
    
    public void LoadOptionData()
    {
        string str_optiondata = File.ReadAllText(Application.dataPath + "/optionData.json");
        g_optiondata = JsonUtility.FromJson<Option_data>(str_optiondata);
    }

    public void SaveOptionData()
    {
        File.WriteAllText(Application.dataPath + "/optionData.json", JsonUtility.ToJson(cur_optiondata, true));
    }
    public void CopyOption()
    {
        cur_optiondata.sound = g_optiondata.sound;
        cur_optiondata.is_kor = g_optiondata.is_kor;
        SoundCheckObjImage.sprite = (cur_optiondata.sound) ? CheckImage : UnCheckImage;
        LanguageCheckObjImage.sprite = (cur_optiondata.is_kor) ? KoreanImage : EnglishImage;
    }


    public void ChangeSound()
    {
        cur_optiondata.sound = !cur_optiondata.sound;
        SoundCheckObjImage.sprite = (cur_optiondata.sound) ? CheckImage : UnCheckImage;
    }
    public void ChangeIsKor()
    {
        cur_optiondata.is_kor = !cur_optiondata.is_kor;
        LanguageCheckObjImage.sprite = (cur_optiondata.is_kor) ? KoreanImage : EnglishImage;
    }

    //Cancel and back.
    public void CancelBackToMenu()
    {
        SceneManager.LoadScene("Main");
    }


    //apply and back.
    public void ApplyBackToMenu()
    {
        SaveOptionData();
        SceneManager.LoadScene("Main");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
