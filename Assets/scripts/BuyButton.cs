using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyButton : MonoBehaviour
{
    public buttonManager BMscript;
    //public GameSystem GSscript;
    // Start is called before the first frame update
    void Start()
    {
        BMscript = GameObject.Find("EventSystem").GetComponent<buttonManager>();
        //GSscript = GameObject.Find("EventSystem").GetComponent<GameSystem>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void BuyTickets()
    {
        if (CanBuyTicket())
        {
            //GlobalMoney.Instance.SubGlobalMoney(BMscript.current_enrolled_number * 1000);
            //GSscript.can_buy = false;
            GameData.Instance.SubGameMoney(BMscript.current_enrolled_number * 1000);
            GameData.Instance.AddPickedNumbersFromPickedArray(BMscript);
            GameData.Instance.SaveGameDataToJson();

            //movemove
            SceneManager.LoadScene("Lottery645result");
        }
    }

    bool CanBuyTicket()
    {
        //if (GSscript.GameMoney >= BMscript.current_enrolled_number * 1000 && GSscript.can_buy)
        if(GameData.Instance.GetGameMoney() >= BMscript.current_enrolled_number * 1000)
            return true;
        else
            return false;
    }


    public void BackButton()
    {
        SceneManager.LoadScene("Main");
    }
}
