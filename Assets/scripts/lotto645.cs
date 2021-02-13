using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lotto645 : MonoBehaviour
{
    
    public int[] pickedNumbers = {0, 0, 0, 0, 0, 0};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void drawPick()
    {
        pickedNumbers[0] = 1;
        pickedNumbers[1] = 2;

    }

    void ShowNumbers()
    {
        for(int i = 0; i < 6; ++i)
        {
            Debug.Log(pickedNumbers[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //ShowNumbers();
    }
}
