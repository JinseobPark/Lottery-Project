using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using System.Data;

[System.Serializable]
public class PickedNumbersToOneGame
{
    public int[] picked_numbers = new int[6];
}


[System.Serializable]
public class OneGame
{
    public string day_time;
    public int[] won_numbers = new int[6];
    public List<PickedNumbersToOneGame> picked_game = new List<PickedNumbersToOneGame>();
    public int take_value;

}

[System.Serializable]
public class GameData_Global
{
    public int global_money;
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
        if (g_gamedata.one_games.Count > 10)
            g_gamedata.one_games.RemoveAt(0);
        g_gamedata.one_games.Add(onegame);
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
    public OneGame GetLastGame()
    {
        return g_gamedata.one_games[g_gamedata.one_games.Count-1];
    }



    public void SaveGameDataToJson()
    {
        for (int i = 0; i < g_gamedata.one_games.Count; i++)
        {
            g_gamedata.one_games[i].picked_game.ToArray();
        }
        g_gamedata.one_games.ToArray();
        File.WriteAllText(Application.dataPath + "/gameData.json", JsonUtility.ToJson(g_gamedata, true));
    }

    public void ReadGameDataFromJson()
    {
        string str_gamedata = File.ReadAllText(Application.dataPath + "/gameData.json");
        g_gamedata = JsonUtility.FromJson<GameData_Global>(str_gamedata);
    }
    // Start is called before the first frame update
    void Start()
    {
        g_gamedata.global_money = start_money;
        ReadGameDataFromJson();
        //SaveGameDataToJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
