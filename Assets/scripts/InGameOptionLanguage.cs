using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InGameOptionLanguage : MonoBehaviour
{
    //Start Image by lang
    public Sprite ResetImage_K;
    public Sprite ResetImage_E;
    //Start Image by lang
    public Sprite AutoImage_K;
    public Sprite AutoImage_E;
    //Start Image by lang
    public Sprite EnrollImage_K;
    public Sprite EnrollImage_E;
    //Start Image by lang
    public Sprite ModifyImage_K;
    public Sprite ModifyImage_E;
    //Start Image by lang
    public Sprite DeleteImage_K;
    public Sprite DeleteImage_E;
    //Start Image by lang
    public Sprite BackImage_K;
    public Sprite BackImage_E;
    //Start Image by lang
    public Sprite BuyImage_K;
    public Sprite BuyImage_E;

    public Image ResetImage;
    public Image AutoImage;
    public Image EnrollImage;
    public Image BackImage;
    public Image BuyImage;

    public Image ModifyImage1;
    public Image ModifyImage2;
    public Image ModifyImage3;
    public Image ModifyImage4;
    public Image ModifyImage5;

    public Image DeleteImage1;
    public Image DeleteImage2;
    public Image DeleteImage3;
    public Image DeleteImage4;
    public Image DeleteImage5;
    // Start is called before the first frame update
    void Start()
    {
        LanguageUpdate();
    }

    public void LanguageUpdate()
    {
        bool IsKorean = OptionData.g_optiondata.GetKorIsTrue();
        ResetImage.sprite   = (IsKorean) ? ResetImage_K  : ResetImage_E;
        AutoImage.sprite    = (IsKorean) ? AutoImage_K   : AutoImage_E;
        EnrollImage.sprite  = (IsKorean) ? EnrollImage_K : EnrollImage_E;
        BackImage.sprite    = (IsKorean) ? BackImage_K   : BackImage_E;
        BuyImage.sprite     = (IsKorean) ? BuyImage_K    : BuyImage_E;

        ModifyImage1.sprite = (IsKorean) ? ModifyImage_K : ModifyImage_E;
        ModifyImage2.sprite = (IsKorean) ? ModifyImage_K : ModifyImage_E;
        ModifyImage3.sprite = (IsKorean) ? ModifyImage_K : ModifyImage_E;
        ModifyImage4.sprite = (IsKorean) ? ModifyImage_K : ModifyImage_E;
        ModifyImage5.sprite = (IsKorean) ? ModifyImage_K : ModifyImage_E;

        DeleteImage1.sprite = (IsKorean) ? DeleteImage_K : DeleteImage_E;
        DeleteImage2.sprite = (IsKorean) ? DeleteImage_K : DeleteImage_E;
        DeleteImage3.sprite = (IsKorean) ? DeleteImage_K : DeleteImage_E;
        DeleteImage4.sprite = (IsKorean) ? DeleteImage_K : DeleteImage_E;
        DeleteImage5.sprite = (IsKorean) ? DeleteImage_K : DeleteImage_E;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
