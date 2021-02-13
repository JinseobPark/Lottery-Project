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
        GlobalMoney.Instance.AddGlobalMoney(takemoney);
    }
}
