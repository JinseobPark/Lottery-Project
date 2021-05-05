using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CurrentMoneyText;
    // Start is called before the first frame update
    void Start()
    {
        CurrentMoneyText.text = " " + GameData.Instance.GetGameMoney();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoneyText.text = " " + GameData.Instance.GetGameMoney();
    }
}
