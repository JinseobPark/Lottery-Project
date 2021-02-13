using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class buttonStat : MonoBehaviour
{
    private bool isPicked = false;
    public int button_number;

    public Sprite PickedImage;
    
    public Sprite NoPickedImage;

    Image image;
    public buttonManager BMscript;
    // Start is called before the first frame update
    void Start()
    {
        BMscript = GameObject.Find("EventSystem").GetComponent<buttonManager>();
        isPicked = false;
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Selected()
    {
        if(isPicked)
        {
            ChangeToNope();
        }
        else if(!isPicked)
        {
            if(BMscript.current_button_number < BMscript.max_button_number)
            {
                ChangeToPick();
            }
            else
            {
                Debug.Log("already picked 6 numbers!!");
            }
        }

    }

    public void ChangeToPick()
    {
        isPicked = true;
        BMscript.Current_picked_number[button_number - 1] = true;
        BMscript.current_button_number++;
        image.sprite = PickedImage;
    }

    public void ChangeToNope()
    {
        isPicked = false;
        BMscript.Current_picked_number[button_number - 1] = false;
        BMscript.current_button_number--;
        image.sprite = NoPickedImage;
    }
}
