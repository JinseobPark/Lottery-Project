using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSystem : MonoBehaviour
{
    //keep for just show number text
    /*
    [System.Serializable]
    public class ShowPickedNumberObjects
    {
        public GameObject[] number_objects = new GameObject[6];
    }
    */
    //public List<ShowPickedNumberObjects> YourPickedObjects;

    public GameObject[] WonGameObjects = new GameObject[6];
    public GameObject WonGameBonusObject;


    public List<int> picked_numbers = new List<int>();
    public int Bonus_number = new int();
    //public bool Matched_bonus = false;

    public OneGame thisGame = new OneGame();

    public WonMoney_List wonmoney;

    public Sprite[] sprites_balls = new Sprite[46];
    
    public void PickWonNumbers()
    {
        picked_numbers.Clear();
        for (int i = 0; i < 7; i++)
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
        Bonus_number = picked_numbers[6];
        picked_numbers.RemoveAt(picked_numbers.Count - 1);
    }

    public void InputWonNumberToGameData()
    {
        for (int i = 0; i < 6; i++)
        {
            thisGame.won_numbers[i] = picked_numbers[i];
        }
        thisGame.won_bonus_number = Bonus_number;
    }

    public void Final_calculate_WonMoney()
    {
        int Money = 0;
        for (int i = 0; i < thisGame.picked_game.Count; i++)
        {
            Money += matchedPrise(CountDiff(thisGame.picked_game[i]), BonusDiff(thisGame.picked_game[i]));
        }
        AudioManager.Audio_Instance.PlayMoneyWinSound(Money);
        thisGame.take_value = Money;

    }

    public void ChangeWonNumberObjects()
    {
        for (int i = 0; i < 6; i++)
        {
            WonGameObjects[i].GetComponent<Image>().sprite = sprites_balls[picked_numbers[i]];
        }
        WonGameBonusObject.GetComponent<Image>().sprite = sprites_balls[Bonus_number];
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
            for (int j = 0; j < 6; j++)
            {
                if (picked_numbers[i] == pickedOneLine.picked_numbers[j])
                    matched++;
            }
        }
        return matched;
    }

    public bool BonusDiff(PickedNumbersToOneGame pickedOneLine)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (Bonus_number == pickedOneLine.picked_numbers[j])
                    return true;
            }
        }

        return false;
    }

    public int matchedPrise(int matchCount, bool bonusmatch)
    {
        switch (matchCount)
        {
            case (0):
            case (1):
            case (2):
                return wonmoney.Get_WonMoney_645_NoneMatch();
            case (3):
                return wonmoney.Get_WonMoney_645_ThreeMatch();
            case (4):
                return wonmoney.Get_WonMoney_645_FourMatch();
            case (5):
                {
                    if (bonusmatch)
                        return wonmoney.Get_WonMoney_645_BonusMatch();
                    else
                        return wonmoney.Get_WonMoney_645_FiveMatch();
                }
            case (6):
                return wonmoney.Get_WonMoney_645_SixMatch();
            default:
                return wonmoney.Get_WonMoney_645_NoneMatch();
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
        InputWonNumberToGameData();
        Final_calculate_WonMoney();
        ChangeWonNumberObjects();

        GameData.Instance.AddGameMoney(thisGame.take_value);
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
