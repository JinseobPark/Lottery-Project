using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_current_money : MonoBehaviour
{
    public TMPro.TextMeshProUGUI CurrentMoneyText;
    // Start is called before the first frame update
    void Start()
    {
        CurrentMoneyText.text = "Money : " + GlobalMoney.Instance.GetGlobalMoney();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoneyText.text = "Money : " + GlobalMoney.Instance.GetGlobalMoney();
    }
}
