using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Result_UI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI MyPickText;
    public TMPro.TextMeshProUGUI WonMoneyText;
    public TMPro.TextMeshProUGUI DayText;

    public ResultSystem resultsystem_sc;

    //Back image for lang
    public Sprite BackImage_E;
    public Sprite BackImage_K;
    public Image BackImage;

    public void ShowWonMoney()
    {
        WonMoneyText.text = "Won Money : " + resultsystem_sc.thisGame.take_value;
    }
    public void ShowMyPickedNumber()
    {
        MyPickText.text = "";
        for (int i = 0; i < resultsystem_sc.thisGame.picked_game.Count; i++)
        {
            MyPickText.text += (i+1) + " Set :  " + PickedNumber(resultsystem_sc.thisGame.picked_game[i]) + "\n\n";
        }
    }

    public string PickedNumber(PickedNumbersToOneGame pickedgame)
    {
        string result = "";
        for (int i = 0; i < 6; i++)
        {
            result += JudgePicked(pickedgame.picked_numbers[i]);
        }

        return result;
    }

    public string JudgePicked(int judgeNumber)
    {
        for (int i = 0; i < 6; i++)
        {
            if (judgeNumber == resultsystem_sc.thisGame.won_numbers[i])
                return " <b>"+ judgeNumber + "</b> ";
            if (judgeNumber == resultsystem_sc.thisGame.won_bonus_number)
                return " <i>" + judgeNumber + "</i> ";
        }
        return " " + judgeNumber + " ";
    }
    public void BackToMenu()
    {
        AudioManager.Audio_Instance.PlayButtonSound();
        SceneManager.LoadScene("Main");
    }

    public void ShowDay()
    {
        DayText.text = "Day : " + resultsystem_sc.thisGame.day_time;
    }

    public void LanguageUpdate()
    {
        bool IsKorean = OptionData.g_optiondata.GetKorIsTrue();
        BackImage.sprite = (IsKorean) ? BackImage_K : BackImage_E;
    }
    // Start is called before the first frame update
    void Start()
    {
        BackImage = GameObject.Find("Back").GetComponent<Image>();
        ShowMyPickedNumber();
        ShowWonMoney();
        LanguageUpdate();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
