using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;


[System.Serializable]
public class OneGame_test
{
    public string day;
    public int[] win_numbers = new int[6];
    public int[] first_picked_numbers = new int[6];
    public int[] second_picked_numbers = new int[6];
    public int[] third_picked_numbers = new int[6];
    public int[] fourth_picked_numbers = new int[6];
    public int[] fifth_picked_numbers = new int[6];
    public int take_value;

}

[System.Serializable]
public class GameData_test
{
    public int m_money;
    public List<OneGame_test> games = new List<OneGame_test>();

    public void printData()
    {
        Debug.Log("Money : " + m_money);

        for (int i = 0; i < games.Count; i++)
        {

        }
    }

}

/*
 //use list to array -> list.ToArray()
[Serializable]
public class ListToArray<T>
{
    [SerializeField]
    List<T> target;

    public List<T> ToList() { return target; }

    public ListToArray(List<T> target)
    {
        this.target = target;
    }
}
*/

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData_test data = new GameData_test();
        data.m_money = 10000;
        //
        //string str = JsonUtility.ToJson(data);
        //
        //Debug.Log("ToJson : " + str);
        //
        //GameData data2 = JsonUtility.FromJson<GameData>(str);
        //data2.printData();
        //
        //GameData data3 = new GameData();
        //data3.m_money = 9000;
        //for (int i = 0; i < 6; ++i)
        //    data3.numbers[i] = i*2;

        //File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(data3));

        //List<OneGame> playedGames = new List<OneGame>();

        OneGame_test firstgame = new OneGame_test();
        firstgame.day = DateTime.Now.ToString();
        for (int i = 0; i < 6; i++)
        {
            firstgame.win_numbers[i] = i * 3;
        }
        for (int i = 0; i < 6; i++)
        {
            firstgame.first_picked_numbers[i] = i * 1;
        }
        for (int i = 0; i < 6; i++)
        {
            firstgame.second_picked_numbers[i] = i * 2;
        }

        data.games.Add(firstgame);

        OneGame_test secondgame = new OneGame_test();
        secondgame.day = DateTime.Now.ToString();
        for (int i = 0; i < 6; i++)
        {
            secondgame.win_numbers[i] = i * 4;
        }
        for (int i = 0; i < 6; i++)
        {
            secondgame.first_picked_numbers[i] = i * 2;
        }
        for (int i = 0; i < 6; i++)
        {
            secondgame.second_picked_numbers[i] = i * 4;
        }

        data.games.Add(secondgame);

        //string str = JsonUtility.ToJson(new Serialization<Enemy>(enemies));

        data.games.ToArray(); //**** list to array. list cant write to json.

        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(data));

        //file load
        string str2 = File.ReadAllText(Application.dataPath + "/TestJson.json");

        GameData_test data4 = JsonUtility.FromJson<GameData_test>(str2);
        data4.printData();

    }

    // Update is called once per frame
    void Update()
    {
        //List<int> hello = new List<int>();
        //hello.RemoveAt(hello.Count);
        
    }
}
