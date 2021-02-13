using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_Button : MonoBehaviour
{
    public ResultSystem resultsystem;
    // Start is called before the first frame update
    void Start()
    {
        resultsystem = GameObject.Find("EventSystem").GetComponent<ResultSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {

    }

    public void PickNumbers()
    { 
    
    }
}
