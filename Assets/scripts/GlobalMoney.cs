using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMoney : MonoBehaviour
{
    public static int global_money;
    public int start_money = 10000;

    public static GlobalMoney _instance;

    //Singleton
    public static GlobalMoney Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(GlobalMoney)) as GlobalMoney;
                if (_instance == null)
                    Debug.LogError("there needs to be one active Global script on a gameobject in your scene");
            }
            return _instance;
        }
    }

    void Awake()
    {
        var obj = FindObjectsOfType<GlobalMoney>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        //DontDestroyOnLoad(this);
    }


    public int GetGlobalMoney()
    {
        return global_money;
    }

    public void SetGlobalMoney(int value)
    {
        global_money = value;
    }

    public void AddGlobalMoney(int value)
    {
        global_money += value;
    }

    public void SubGlobalMoney(int value)
    {
        global_money -= value;
    }


    // Start is called before the first frame update
    void Start()
    {
        global_money = start_money;

    }

    // Update is called once per frame
    //void Update()
    //{

    //}
}
