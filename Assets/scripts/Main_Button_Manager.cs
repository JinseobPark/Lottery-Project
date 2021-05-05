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
    
    private Image StartImage;
    private Image OptionImage;
    private Image BillImage;

    void Start()
    {
        StartImage = GameObject.Find("Start").GetComponent<Image>();
        OptionImage = GameObject.Find("Option").GetComponent<Image>();
        BillImage = GameObject.Find("Bill").GetComponent<Image>();
        LanguageUpdate();
    }

    public void LanguageUpdate()
    {
        bool IsKorean = OptionData.g_optiondata.GetKorIsTrue();
        StartImage.sprite  = (IsKorean) ? StartImage_K  : StartImage_E;
        OptionImage.sprite = (IsKorean) ? OptionImage_K : OptionImage_E;
        BillImage.sprite   = (IsKorean) ? BillImage_K   : BillImage_E;
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene("Lottery645");
    }

    public void GiveMoneyButton()
    {
        GameData.Instance.AddGameMoney(takemoney);
    }

    public void ShowBillButton()
    {
        SceneManager.LoadScene("Bill_Scene");
    }


    public void OptionButton()
    {
        SceneManager.LoadScene("Option");
    }

}
