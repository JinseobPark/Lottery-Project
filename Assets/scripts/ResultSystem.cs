using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSystem : MonoBehaviour
{
    public List<GameObject> picked_objects = new List<GameObject>();
    public List<int> picked_numbers = new List<int>();

    public OneGame thisGame = new OneGame();

    public int NoneMatchPrise = 0;
    public int ThreeMatchPrise = 5000;
    public int FourMatchPrise = 50000;
    public int FiveMatchPrise = 1000000;
    public int BonusMatchPrise = 50000000;
    public int SixMatchPrise = 2000000000;



    public void PickWonNumbers()
    {
        picked_numbers.Clear();
        for (int i = 0; i < 6; i++)
        {
            int random_number = Random.Range(1, 46);
            picked_numbers.Add(random_number);
            //Debug.Log("array size : " + picked_numbers.Count);
            for (int checker = 0; checker < picked_numbers.Count - 1; ++checker)
            {
                //Debug.Log("array :  " + picked_numbers[checker] + "   random number :  " + random_number);
                if (picked_numbers[checker] == random_number)
                {
                    Debug.Log("same!!");
                    i--;
                    picked_numbers.RemoveAt(picked_numbers.Count - 1);
                    break;
                }
            }
        }
    }

    public void InputDataWonNumber()
    {
        for (int i = 0; i < 6; i++)
        {
            thisGame.won_numbers[i] = picked_numbers[i];
        }
    }

    public void InputWonMoney()
    {
        int Money = 0;
        for (int i = 0; i < thisGame.picked_game.Count; i++)
        {
            Money += matchedPrise(CountDiff(thisGame.picked_game[i]));
        }

        thisGame.take_value = Money;

        //return Money;
    }

    public void ResortWonNumbers()
    {
        picked_numbers.Sort();
    }

    public int CountDiff(PickedNumbersToOneGame pickedOneLine)
    {
        int matched = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j= 0; j < 6; j++)
            {
                if (picked_numbers[i] == pickedOneLine.picked_numbers[j])
                    matched++;
            }
        }
        return matched;
    }

    public int matchedPrise(int matchCount)
    {
        switch(matchCount)
        {
            case (0):
            case (1):
            case (2):
                return 0;
            case (3):
                return ThreeMatchPrise;
            case (4):
                return FourMatchPrise;
            case (5):
                return FiveMatchPrise;
            case (6):
                return SixMatchPrise;
            default:
                return NoneMatchPrise ;
        }
    }
    public void ShowWonNumbersToText()
    {
        Debug.Log(picked_numbers);
        //for (int i = 0; i < picked_numbers.Count; i++)
        //{
        //    Debug.Log(picked_numbers[i]);
        //}
    }

    public void ProgressTheGame()
    {
        GameData.Instance.ReadGameDataFromJson();
        thisGame = GameData.Instance.GetLastGame();

        PickWonNumbers();
        ResortWonNumbers();
        ShowWonNumbersToText();
        InputDataWonNumber();
        InputWonMoney();

        GameData.Instance.UpdateLastGame(thisGame);

        GameData.Instance.SaveGameDataToJson();
    }
    // Start is called before the first frame update
    void Start()
    {
        ProgressTheGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PickWonNumbers();
            ShowWonNumbersToText();
        }
    }
}
