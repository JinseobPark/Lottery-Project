using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result_Button : MonoBehaviour
{
    //public ResultSystem resultsystem;
    // Start is called before the first frame update
    void Start()
    {
        //resultsystem = GameObject.Find("EventSystem").GetComponent<ResultSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {

        SceneManager.LoadScene("Main");
    }

    public void PickNumbers()
    { 
    
    }
}
