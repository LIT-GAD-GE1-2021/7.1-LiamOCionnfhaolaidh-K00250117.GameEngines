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

    public float valkyrieCount = 1;
    public float vbuckCost = 4;
    public AudioSource crowNoise;

    public Text gameOverText;
    public bool deathCHeck;
    public bool bringThePlayerBack;

    public Image firstHeart;
    public Image secondHeart;
    public Image thirdHeart;


    public Rigidbody2D theRB;
    public float fireForce;


    public bool moneyCheck;



    public void SpendMoney()
    {         
            if (coinCounter >= 3)
            {

                 coinCounter -= 3;

               //  Debug.Log("Spent Money");

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

    public void VBuckCollect()
    {

        valkyrieCount += 1;
        crowNoise.Play();
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

        gameOverText.text = "Pay " + vbuckCost.ToString() + " Valkyrie Bucks to save yourself? Bucks:" + valkyrieCount.ToString() + "(Press Y or N)";
        deathCHeck = true;
        gameOverText.enabled = true;

    }

   
    public void BackToLife()
    {
        thirdHeart.enabled = true;

        secondHeart.enabled = true;

        firstHeart.enabled = true;

        gameOverText.enabled = false;

        deathCHeck = false;


    }

    void Update()
    {
        coinText.text = coinCounter.ToString() + "KR";


        if (coinCounter < 0)
        {

            coinCounter = 0;

        }

        if (Input.GetKeyDown(KeyCode.Y) == true && deathCHeck == true)
        {
           if (valkyrieCount >= vbuckCost)
            {
               BackToLife();

               deathCHeck = false;
               vbuckCost += 2;
               bringThePlayerBack = true;
               valkyrieCount -= vbuckCost;


            }

        }


        if (bringThePlayerBack == true)
        {

            gameOverText.enabled = false;

            gameOverText.gameObject.SetActive(false);

        }

    }

    void Start()
    {
        gameOverText.enabled = false;


    }




    private void Awake()
    {

        instance = this;
    }


}
