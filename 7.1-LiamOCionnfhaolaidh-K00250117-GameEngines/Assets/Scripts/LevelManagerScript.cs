using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{

    public static LevelManagerScript instance;

    private float coinCounter = 0;
    public Text coinText;
    public Image firstHeart;
    public Image secondHeart;
    public Image thirdHeart;


    public Rigidbody2D theRB;
    public float fireForce;


    public bool directionCheck;



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


    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCounter.ToString() + "KR";



    }

    private void Awake()
    {
        // set the instance property/variable to this object
        instance = this;
    }


}
