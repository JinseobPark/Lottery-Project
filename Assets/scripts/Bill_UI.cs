using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bill_UI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Bill_Left_Text;
    public TMPro.TextMeshProUGUI Bill_Right_Text;

    public int currentPageNumber = 1;
    public int MaxPageNumber;
    public bool needEmptyPage;

    public int leftPageNumber;
    public int RightPageNumber;

    public OneGame leftOneGame;
    public OneGame rightOneGame;
    // Start is called before the first frame update
    void Start()
    {
        MaxPageNumber = (GameData.g_gamedata.one_games.Count + 1) / 2;
        needEmptyPage = CheckNeedEmptyPage(GameData.g_gamedata.one_games.Count);

        ShowPages(); 
    }

    public bool CheckNeedEmptyPage(int ToModTwo)
    {
        if (ToModTwo % 2 == 1)
            return true;
        else
        return false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public string ShowDay(OneGame one_game)
    {
        return one_game.day_time + "\n";
    }

    public string ShowWonNumber(OneGame one_game)
    {
        string result = " ";
        for (int i = 0; i < 6; i++)
        {
            result += one_game.won_numbers[i] + " ";
        }
        result += " + " + one_game.won_bonus_number + "\n";

        return result;
    }

    public string ShowPickedNumber(OneGame one_game)
    {
        string result = " ";

        for (int i = 0; i < one_game.picked_game.Count; i++)
        {
            result += (i + 1) + " Set :  " + PickedNumber(one_game.picked_game[i], one_game) + "\n";
        }
        for (int reverse = 5; reverse > one_game.picked_game.Count; reverse--)
        {
            result += "\n";
        }

        return result;
    }

    public string PickedNumber(PickedNumbersToOneGame pickedgame, OneGame one_game)
    {
        string result = "";
        for (int i = 0; i < 6; i++)
        {
            result += JudgePicked(pickedgame.picked_numbers[i], one_game);
        }

        return result;
    }

    public string JudgePicked(int judgeNumber, OneGame one_game)
    {
        for (int i = 0; i < 6; i++)
        {
            if (judgeNumber == one_game.won_numbers[i])
                return " <b>" + judgeNumber + "</b> ";
            if (judgeNumber == one_game.won_bonus_number)
                return " <i>" + judgeNumber + "</i> ";
        }
        return " " + judgeNumber + " ";
    }

    public string ShowGotMoney(OneGame one_game)
    {
        string money = "";
        money += one_game.take_value;
        return money;
    }


    public void ShowLeftPage()
    {
        leftPageNumber = 1 + (currentPageNumber - 1) * 2;
        leftOneGame = GameData.g_gamedata.one_games[leftPageNumber];
        Bill_Left_Text.text = " " + ShowDay(leftOneGame) + ShowWonNumber(leftOneGame) + ShowPickedNumber(leftOneGame) + ShowGotMoney(leftOneGame);
        /*Day + won number + picked number + money*/
    }

    public void ShowRightPage()
    {

    }

    public void ShowPages()
    {
        ShowLeftPage();
        ShowRightPage();
    }

    public void GoLeftPage()
    {
        if (currentPageNumber > 1)
        {
            currentPageNumber -= 1;
            ShowPages();
        }
    }

    public void GoRightPage()
    {
        if(currentPageNumber < MaxPageNumber)
        {
            currentPageNumber += 1;
            ShowPages();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
