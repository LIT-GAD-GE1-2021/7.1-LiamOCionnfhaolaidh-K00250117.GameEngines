using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{

    public static LevelManagerScript instance;

    public float coinCounter = 0;
    public Text coinText;
    public Image firstHeart;
    public Image secondHeart;
    public Image thirdHeart;


    public Rigidbody2D theRB;
    public float fireForce;


    public bool moneyCheck;

    public void SpendMoney()
    {


          //  Debug.Log("Pressed Down"); 
            
            if (coinCounter >= 3)
            {

                 coinCounter -= 3;

                 Debug.Log("Spent Money");

                 moneyCheck = true;

            }

            else if(coinCounter < 3)
            {

              moneyCheck = false;

            }

       


    }

    public void KronerCollect()
    {

        coinCounter += 1;

    }




    public void TakeDamage1()
    {
        thirdHeart.enabled = false;

    }

    public void TakeMoreDamage()
    {
        secondHeart.enabled = false;

    }

    public void TakeEvenMoreDamage()
    {

        firstHeart.enabled = false;

    }



    void Update()
    {
        coinText.text = coinCounter.ToString() + "KR";

        if (coinCounter < 0)
        {

            coinCounter = 0;

        }




    }

    private void Awake()
    {

        instance = this;
    }


}
