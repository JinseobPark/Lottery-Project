using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class Option_UI : MonoBehaviour
{
    //public static Option_data g_optiondata = new Option_data();
    public Option_data cur_optiondata = new Option_data();

    //checker
    public Sprite CheckImage;
    public Sprite UnCheckImage;
    //current language
    public Sprite KoreanImage;
    public Sprite EnglishImage;
    //report image
    public Sprite ReportImage_E;
    public Sprite ReportImage_K;
    //sound image for lang
    public Sprite SoundImage_E;
    public Sprite SoundImage_K;

    //lang image for lang
    public Sprite LangImage_E;
    public Sprite LangImage_K;

    //apply image for lang
    public Sprite ApplyImage_E;
    public Sprite ApplyImage_K;
    //cancel image for lang
    public Sprite CancelImage_E;
    public Sprite CancelImage_K;
    //reset Image by lang
    public Sprite ResetImage_K;
    public Sprite ResetImage_E;
    //reset Image by lang
    public Sprite CautionImage_K;
    public Sprite CautionImage_E;

    private Image SoundCheckObjImage;
    private Image LanguageCheckObjImage;
    private Image ReportImage;
    private Image SoundImage;
    private Image LangImage;
    private Image ApplyImage;
    private Image CancelImage;
    private Image ResetImage;
    private Image CautionImage;

    // Start is called before the first frame update
    void Start()
    {
        SoundCheckObjImage = GameObject.Find("SoundButton").GetComponent<Image>();
        LanguageCheckObjImage = GameObject.Find("LanguageButton").GetComponent<Image>();
        ReportImage = GameObject.Find("Report").GetComponent<Image>();
        SoundImage = GameObject.Find("Sound").GetComponent<Image>();
        LangImage = GameObject.Find("Language").GetComponent<Image>();
        ApplyImage = GameObject.Find("Apply").GetComponent<Image>();
        CancelImage = GameObject.Find("Cancel").GetComponent<Image>();
        ResetImage = GameObject.Find("Reset").GetComponent<Image>();
        CautionImage = GameObject.Find("Caution").GetComponent<Image>();
        LoadOptionDataToTemp();
        ChangeLanguage();
    }
    
    public void LoadOptionDataToTemp()
    {
        cur_optiondata.SetOption(OptionData.g_optiondata.GetSoundIsTrue(), OptionData.g_optiondata.GetKorIsTrue());
        SoundCheckObjImage.sprite = (cur_optiondata.GetSoundIsTrue()) ? CheckImage : UnCheckImage;
        LanguageCheckObjImage.sprite = (cur_optiondata.GetKorIsTrue()) ? KoreanImage : EnglishImage;
    }

    public void SaveOptionData()
    {
        OptionData.Option_Instance.SaveOptionData(cur_optiondata);
        OptionData.g_optiondata.SetOption(cur_optiondata.GetSoundIsTrue(), cur_optiondata.GetKorIsTrue());
    }

    public void ChangeSound()
    {
        cur_optiondata.SetSound(!cur_optiondata.GetSoundIsTrue());
        SoundCheckObjImage.sprite = (cur_optiondata.GetSoundIsTrue()) ? CheckImage : UnCheckImage;
    }
    public void ChangeIsKor()
    {
        cur_optiondata.SetLanguage(!cur_optiondata.GetKorIsTrue());
        LanguageCheckObjImage.sprite = (cur_optiondata.GetKorIsTrue()) ? KoreanImage : EnglishImage;
        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        ReportImage.sprite  = (cur_optiondata.GetKorIsTrue()) ? ReportImage_K : ReportImage_E;
        SoundImage.sprite   = (cur_optiondata.GetKorIsTrue()) ? SoundImage_K  : SoundImage_E;
        LangImage.sprite    = (cur_optiondata.GetKorIsTrue()) ? LangImage_K   : LangImage_E;
        ApplyImage.sprite   = (cur_optiondata.GetKorIsTrue()) ? ApplyImage_K  : ApplyImage_E;
        CancelImage.sprite  = (cur_optiondata.GetKorIsTrue()) ? CancelImage_K : CancelImage_E;
        ResetImage.sprite   = (cur_optiondata.GetKorIsTrue()) ? ResetImage_K  : ResetImage_E;
        CautionImage.sprite = (cur_optiondata.GetKorIsTrue()) ? CautionImage_K : CautionImage_E;
    }
    //Cancel and back.
    public void CancelBackToMenu()
    {
        AudioManager.Audio_Instance.PlayButtonSound();
        SceneManager.LoadScene("Main");
    }

    public void ResetButton()
    {
        //Warnning!!
        GameData.Instance.ClearData();
        GameData.Instance.SaveGameDataToJson();
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
