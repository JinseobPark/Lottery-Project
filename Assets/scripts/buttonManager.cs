using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PickedArray
{
    public bool ispicked = false;
    public List<int> picked_numbers = new List<int>();
    public List<GameObject> picked_balls = new List<GameObject>();
    public GameObject button_modify;
    public GameObject button_delete;
}


public class buttonManager : MonoBehaviour
{
    public GameObject[] buttonNumbers = new GameObject[45];
    public bool[] Current_picked_number;
    public int max_button_number = 6;
    public int current_button_number;
    public int max_enrolled_number = 5;
    public int current_enrolled_number;
    public int current_going_list;
    public PickedArray[] pickedArrays;

    public Sprite[] picked_balls = new Sprite[46];

    // Start is called before the first frame update
    void Start()
    {
        //inialize to false.
        Current_picked_number = new bool[45];
        for (int i = 0; i < 45; ++i)
            Current_picked_number[i] = false;

        //pickedArrays = new PickedArray[5];
        for (int i = 0; i < 5; ++i)
        {
            //pickedArrays[i].ispicked = true;
            //pickedArrays[i].picked_numbers.
        }
        max_button_number = 6;
        current_button_number = 0;
        current_enrolled_number = 0;
        current_going_list = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
