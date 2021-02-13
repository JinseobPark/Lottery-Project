using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class OneGame
{
    public string day;
    public int[] win_numbers = new int[6];
    public int[] picked_numbers = new int[6];

}

[System.Serializable]
public class GameData
{
    public int m_money;
    public int[] numbers = new int[6];

    public void printData()
    {
        Debug.Log("Money : " + m_money);
        Debug.Log("picked number : " + numbers[0] + numbers[1] + numbers[2] + numbers[3] + numbers[4] + numbers[5]);
    }

}


public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData data = new GameData();
        data.m_money = 10000;
        for (int i = 0; i < 6; ++i)
            data.numbers[i] = i;


        string str = JsonUtility.ToJson(data);

        Debug.Log("ToJson : " + str);

        GameData data2 = JsonUtility.FromJson<GameData>(str);
        data2.printData();

        GameData data3 = new GameData();
        data3.m_money = 9000;
        for (int i = 0; i < 6; ++i)
            data3.numbers[i] = i*2;

        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(data3));

        //file load
        string str2 = File.ReadAllText(Application.dataPath + "/TestJson.json");

        GameData data4 = JsonUtility.FromJson<GameData>(str2);
        data4.printData();

    }

    // Update is called once per frame
    void Update()
    {
        //List<int> hello = new List<int>();
        //hello.RemoveAt(hello.Count);
        
    }
}
