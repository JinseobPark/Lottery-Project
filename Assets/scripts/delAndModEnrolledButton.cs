using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class delAndModEnrolledButton : MonoBehaviour
{
    public int line_number = 0;

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

    public void Delete_enrolled_balls()
    {
        BMscript.pickedArrays[line_number-1].ispicked = false;
        BMscript.pickedArrays[line_number-1].picked_numbers.Clear();

        for (int i = 0; i < 6; ++i)
            BMscript.pickedArrays[line_number-1].picked_balls[i].GetComponent<Image>().sprite = BMscript.picked_balls[0];

        for (int i = 0; i < 45; ++i)
        {
            BMscript.buttonNumbers[i].GetComponent<buttonStat>().ChangeToNope();
        }
        BMscript.current_button_number = 0;
        BMscript.current_going_list = 0;
        BMscript.current_enrolled_number--;
    }

    public void Modify_enrolled_balls()
    {
        if (BMscript.pickedArrays[line_number - 1].ispicked)
        {
            for (int i = 0; i < 45; ++i)
            {
                BMscript.buttonNumbers[i].GetComponent<buttonStat>().ChangeToNope();
            }

            for (int i = 0; i < 6; ++i)
            {
                int picked_number = BMscript.pickedArrays[line_number-1].picked_numbers[i];
                BMscript.buttonNumbers[picked_number-1].GetComponent<buttonStat>().ChangeToPick();
            }

            BMscript.pickedArrays[line_number - 1].picked_numbers.Clear();
            BMscript.current_button_number = 6;


            BMscript.current_going_list = line_number;
        }





    }

}
