using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Option_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void ChangeApply()
    {

    }

    //Cancel and back.
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main");
    }


    //apply and back.
    public void ApplyBackToMenu()
    {
        ChangeApply();
        SceneManager.LoadScene("Main");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
