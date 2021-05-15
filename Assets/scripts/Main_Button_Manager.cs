using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Main_Button_Manager : MonoBehaviour
{
    public int takemoney = 5000;
    // Start is called before the first frame update

    //Start Image by lang
    public Sprite StartImage_K;
    public Sprite StartImage_E;
    //option Image by lang
    public Sprite OptionImage_K;
    public Sprite OptionImage_E;
    //bill Image by lang
    public Sprite BillImage_K;
    public Sprite BillImage_E;
    //Info Image by lang
    public Sprite InfoImage_K;
    public Sprite InfoImage_E;

    private Image StartImage;
    private Image OptionImage;
    private Image BillImage;
    private Image InfoImage;

    public bool IsShowInfo;
    void Start()
    {
        CheckAndPlayBGM();
        StartImage = GameObject.Find("Start").GetComponent<Image>();
        OptionImage = GameObject.Find("Option").GetComponent<Image>();
        BillImage = GameObject.Find("Bill").GetComponent<Image>();
        InfoImage = GameObject.Find("InfoBox").GetComponent<Image>();
        IsShowInfo = false;
        LanguageUpdate();
    }

    void CheckAndPlayBGM()
    {
        if(OptionData.g_optiondata.GetSoundIsTrue())
        {
            if (!AudioManager.Audio_Instance.IsPlayBGM())
             AudioManager.Audio_Instance.PlayBGMSound();
        }
        else
        {
            AudioManager.Audio_Instance.StopBGMSound();
        }
    }
    public void LanguageUpdate()
    {
        bool IsKorean = OptionData.g_optiondata.GetKorIsTrue();
        StartImage.sprite  = (IsKorean) ? StartImage_K  : StartImage_E;
        OptionImage.sprite = (IsKorean) ? OptionImage_K : OptionImage_E;
        BillImage.sprite   = (IsKorean) ? BillImage_K   : BillImage_E;
        InfoImage.sprite   = (IsKorean) ? InfoImage_K   : InfoImage_E;
    }
    public void StartGameButton()
    {
        AudioManager.Audio_Instance.PlayButtonSound();
        SceneManager.LoadScene("Lottery645");
    }

    public void GiveMoneyButton()
    {
        AudioManager.Audio_Instance.PlayButtonSound();
        GameData.Instance.AddGameMoney(takemoney);
    }

    public void ShowBillButton()
    {
        AudioManager.Audio_Instance.PlayButtonSound();
        SceneManager.LoadScene("Bill_Scene");
    }


    public void OptionButton()
    {
        AudioManager.Audio_Instance.PlayButtonSound();
        SceneManager.LoadScene("Option");
    }

    public void QuestionBoxButton()
    {
        IsShowInfo = !IsShowInfo;
        InfoImage.enabled = (IsShowInfo) ? true : false;
    }

}
