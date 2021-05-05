using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTimer : MonoBehaviour
{
    public float NextTimer = 3.0f;
    //private float start_time;
    private float current_time;

    //Cancel and back.
    public void GoToMain()
    {
        SceneManager.LoadScene("Main");
    }
    // Start is called before the first frame update
    void Start()
    {
        //start_time = Time.time;
        current_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        current_time += Time.deltaTime;
        if(current_time > NextTimer)
        {
            GoToMain();
        }
    }
}
