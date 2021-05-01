using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Button_Manager : MonoBehaviour
{
    public int takemoney = 5000;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

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

    public void ResetButton()
    {
        //Warnning!!
        GameData.Instance.ClearData();
        GameData.Instance.SaveGameDataToJson();
    }

    public void OptionButton()
    {
        SceneManager.LoadScene("Option");
    }

}
