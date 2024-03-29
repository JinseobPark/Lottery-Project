﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using System.Globalization;
using System.Data;

[System.Serializable]
public class PickedNumbersToOneGame
{
    public int[] picked_numbers = new int[6];
}

[System.Serializable]
public class WonMoney_List
{
    public int WonMoney_645_NoneMatch = 0;
    public int WonMoney_645_ThreeMatch = 5000;
    public int WonMoney_645_FourMatch = 50000;
    public int WonMoney_645_FiveMatch = 1000000;
    public int WonMoney_645_BonusMatch = 50000000;
    public int WonMoney_645_SixMatch = 2000000000;

    public int Get_WonMoney_645_NoneMatch()
    {
        return WonMoney_645_NoneMatch;
    }
    public int Get_WonMoney_645_ThreeMatch()
    {
        return WonMoney_645_ThreeMatch;
    }
    public int Get_WonMoney_645_FourMatch()
    {
        return WonMoney_645_FourMatch;
    }
    public int Get_WonMoney_645_FiveMatch()
    {
        return WonMoney_645_FiveMatch;
    }
    public int Get_WonMoney_645_BonusMatch()
    {
        return WonMoney_645_BonusMatch;
    }
    public int Get_WonMoney_645_SixMatch()
    {
        return WonMoney_645_SixMatch;
    }
}

[System.Serializable]
public class OneGame
{
    public string day_time;
    public int[] won_numbers = new int[6];
    public int won_bonus_number;
    public List<PickedNumbersToOneGame> picked_game = new List<PickedNumbersToOneGame>();
    public int take_value;

}

[System.Serializable]
public class GameData_Global
{
    public int global_money;
    public string lastGetTime;
    public WonMoney_List WonMoney = new WonMoney_List();
    public List<OneGame> one_games = new List<OneGame>();
}
public class GameData : MonoBehaviour
{
    public static GameData_Global g_gamedata = new GameData_Global();
    public int start_money = 10000;

    public static GameData _instance;

    //Singleton
    public static GameData Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(GameData)) as GameData;
                if (_instance == null)
                    Debug.LogError("there needs to be one active Global script");
            }
            return _instance;
        }
    }

    void Awake()
    {
        var obj = FindObjectsOfType<GameData>();

        if(obj.Length == 1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        g_gamedata.global_money = start_money;
        ReadGameDataFromJson();
        GetTimeMoney();

    }

    public int GetGameMoney()
    {
        return g_gamedata.global_money;
    }

    public void SetGameMoney(int value)
    {
        g_gamedata.global_money = value;
    }

    public void AddGameMoney(int value)
    {
        g_gamedata.global_money += value;
    }

    public void SubGameMoney(int value)
    {
        g_gamedata.global_money -= value;
    }


    public void AddOneGames(OneGame onegame)
    {
        //if more 10 games, delete oldest game.
        if (g_gamedata.one_games.Count >= 10)
        {
            for (int i = g_gamedata.one_games.Count - 1; i >= 9; --i)
                g_gamedata.one_games.RemoveAt(i);
        }
        //g_gamedata.one_games.Add(onegame);
        g_gamedata.one_games.Insert(0, onegame);
    }

    public void ClearData()
    {
        g_gamedata.global_money = 0;
        g_gamedata.one_games.Clear();
        g_gamedata.lastGetTime = DateTime.Now.ToString("yyyy-MM-dd");
    }

    public void AddPickedNumbersFromPickedArray(buttonManager pickedArray)
    {
        OneGame addToOnegame = new OneGame();
        addToOnegame.day_time = DateTime.Now.ToString();
        for (int i = 0; i < pickedArray.current_enrolled_number; i++)
        {
            PickedNumbersToOneGame inst_Numbers = new PickedNumbersToOneGame();
            for (int number = 0; number < 6; number++)
            {
                inst_Numbers.picked_numbers[number] = pickedArray.pickedArrays[i].picked_numbers[number];
            }
            addToOnegame.picked_game.Add(inst_Numbers);
        }

        AddOneGames(addToOnegame);
    }

    public void UpdateLastGame(OneGame updateGame)
    {
        g_gamedata.one_games[0].day_time = updateGame.day_time;
        g_gamedata.one_games[0].picked_game = updateGame.picked_game;
        g_gamedata.one_games[0].won_numbers = updateGame.won_numbers;
        g_gamedata.one_games[0].take_value = updateGame.take_value;
    }

    public OneGame GetLastGame()
    {
        return g_gamedata.one_games[0];
    }

    public void GetTimeMoney()
    {
        if(TryGetMoney())
        {
            g_gamedata.global_money = start_money;
            g_gamedata.lastGetTime = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }

    public bool TryGetMoney()
    {
        DateTime Nowtime = DateTime.Now;
        DateTime LastGetTime;
        try
        {
            LastGetTime = DateTime.ParseExact(g_gamedata.lastGetTime, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        catch(Exception e)
        {
            LastGetTime = DateTime.Now;
            g_gamedata.lastGetTime = DateTime.Now.ToString("yyyy-MM-dd");
            g_gamedata.global_money = start_money;

            Debug.Log("couldn't converse time to lastGetTime:" + e.Message);
        }
        int timeCal = Nowtime.Day - LastGetTime.Day;

        return (timeCal >= 1) ? true : false;
    }

    public void SaveGameDataToJson()
    {
        string gamedatafilePath = Application.persistentDataPath + "/gameData.json";
        for (int i = 0; i < g_gamedata.one_games.Count; i++)
        {
            g_gamedata.one_games[i].picked_game.ToArray();
        }
        //g_gamedata.WonMoney.ToString();
        g_gamedata.one_games.ToArray();
        File.WriteAllText(gamedatafilePath, JsonUtility.ToJson(g_gamedata, true));
    }

    public void ReadGameDataFromJson()
    {
        string gamedatafilePath = Application.persistentDataPath + "/gameData.json";
        try
        {
            string str_gamedata = File.ReadAllText(gamedatafilePath);
            g_gamedata = JsonUtility.FromJson<GameData_Global>(str_gamedata);
        }
        catch
        {
            ClearData();
            SetGameMoney(start_money);
            File.WriteAllText(gamedatafilePath, JsonUtility.ToJson(g_gamedata, true));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //SaveGameDataToJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
