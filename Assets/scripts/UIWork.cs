using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class UIWork : MonoBehaviour
{
    public buttonManager BMscript;
    // Start is called before the first frame update
    void Start()
    {
        BMscript = GameObject.Find("EventSystem").GetComponent<buttonManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset_Numbers()
    {
        for (int i = 0; i < 45; ++i)
        {
            BMscript.buttonNumbers[i].GetComponent<buttonStat>().ChangeToNope();
        }
        BMscript.current_button_number = 0;
        BMscript.current_going_list = 0;
        AudioManager.Audio_Instance.PlayButtonSound();
    }

    public void Enroll_numbers()
    {
        if(BMscript.current_button_number == BMscript.max_button_number)
        {
            if(Able_enroll())
            {
                //enroll
                Reset_Numbers();
            }
            else
            {
                Debug.Log("max array!");
            }
        }
        else
        {
            //cant enroll
            Debug.Log("Pick 6 numbers");
        }
        AudioManager.Audio_Instance.PlayButtonSound();
    }


    public void AutoPick()
    {
        if (BMscript.current_button_number < BMscript.max_button_number) //if picked 0~5
        {
            int diff_count = BMscript.max_button_number - BMscript.current_button_number;
            for (int i = 0; i < diff_count; i++)
            {
                //pick number randomly
                int ramdom_number = Random.Range(1, 46);
                if(!BMscript.Current_picked_number[ramdom_number - 1]) // already not picked
                {
                    BMscript.buttonNumbers[ramdom_number - 1].GetComponent<buttonStat>().Selected();
                }
                else
                {
                    i--;
                }
            }
            /*
             
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
             */
        }
        //else. nope change.
        AudioManager.Audio_Instance.PlayButtonSound();
    }

    bool Able_enroll()
    {

        /*if (BMscript.current_going_list != 0)
        {
            Debug.Log("try to modify");
            BMscript.pickedArrays[BMscript.current_going_list - 1].ispicked = true;
            for (int j = 0; j < 45; ++j)
            {
                if (BMscript.Current_picked_number[j])
                    BMscript.pickedArrays[BMscript.current_going_list - 1].picked_numbers.Add(j + 1);
            }
            for (int j = 0; j < 6; ++j)
            {
                int pickedNumber = BMscript.pickedArrays[BMscript.current_going_list - 1].picked_numbers[j];
                BMscript.pickedArrays[BMscript.current_going_list - 1].picked_balls[j].GetComponent<Image>().sprite = BMscript.picked_balls[pickedNumber];
            }
            BMscript.current_going_list = 0;
            return true;
        }
        */
        if (BMscript.current_enrolled_number < BMscript.max_enrolled_number)
        {
            Debug.Log("try enroll");

            for (int i = 0; i < BMscript.max_enrolled_number; ++i)
            {
                Debug.Log("find in empty...");
                if (BMscript.pickedArrays[i].ispicked == false)
                {
                    Debug.Log("found the empty");
                    BMscript.pickedArrays[i].ispicked = true;
                    for (int j = 0; j < 45; ++j)
                    {
                        if (BMscript.Current_picked_number[j])
                        BMscript.pickedArrays[i].picked_numbers.Add(j + 1);
                    }
                    for(int j = 0; j < 6; ++j)
                    {
                        int pickedNumber = BMscript.pickedArrays[i].picked_numbers[j];
                        BMscript.pickedArrays[i].picked_balls[j].GetComponent<Image>().sprite = BMscript.picked_balls[pickedNumber];
                    }
                    BMscript.current_going_list = 0;
                    BMscript.current_enrolled_number++;
                    Debug.Log("sucess to enroll");
                    return true;
                }

            }
            Debug.Log("not found empty");
            return false;
        }

        return false;
    }



}
