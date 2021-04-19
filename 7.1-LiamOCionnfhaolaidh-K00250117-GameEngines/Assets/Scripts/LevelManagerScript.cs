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
    public Text gameOverText;
    public Image firstHeart;
    public Image secondHeart;
    public Image thirdHeart;

    public float valkyrieCount = 10;
    public float vbuckCost = 4;

    public AudioSource crowNoise;
    public AudioSource kronerNoise;
    public AudioSource vendingSound;

    public bool deathCheck;
    public bool bringThePlayerBack;

    public Rigidbody2D theRB;
    public float fireForce;

    public bool moneyCheck;



    public void SpendMoney()
    {         
            if (coinCounter >= 3)
            {
               //  Debug.Log("Spent Money");
                 coinCounter -= 3;
                 moneyCheck = true;
                 vendingSound.Play();
                 

            }

            else if(coinCounter < 3)
            {

              moneyCheck = false;

            }
    }

    public void KronerCollect()
    {

        coinCounter += 1;
        kronerNoise.Play();

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
        deathCheck = true;

        gameOverText.enabled = true;


    }

   
    public void BackToLife()
    {
        thirdHeart.enabled = true;

        secondHeart.enabled = true;

        firstHeart.enabled = true;

        gameOverText.enabled = false;

        deathCheck = false;


    }

    IEnumerator PlayerBackFalse()
    {

        yield return new WaitForSeconds(0.1f);
        bringThePlayerBack = false;



    }


    void Update()
    {
        coinText.text = coinCounter.ToString() + "KR";


        if (coinCounter < 0)
        {

            coinCounter = 0;

        }

        if (Input.GetKeyDown(KeyCode.Y) == true && deathCheck == true)
        {
           if (valkyrieCount >= vbuckCost)
            {
               BackToLife();

               deathCheck = false;
               bringThePlayerBack = true;

               valkyrieCount -= vbuckCost;
               vbuckCost += 1;

            }

        }

        if (Input.GetKeyDown(KeyCode.N) == true && deathCheck == true)
        {
                BackToLife();

                deathCheck = false;
                bringThePlayerBack = true;

        }




        if (bringThePlayerBack == true)
        {

            gameOverText.enabled = false;

            StartCoroutine("PlayerBackFalse");

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
