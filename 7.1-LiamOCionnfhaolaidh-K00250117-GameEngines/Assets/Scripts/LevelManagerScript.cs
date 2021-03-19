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
    public float minusFireForce = -5;

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

    public void FireScript()
    {

        if (directionCheck == true)
        {


            theRB.AddForce(Vector2.right * minusFireForce, ForceMode2D.Impulse);

           // Debug.Log("left");
        }

        if (directionCheck == false)
        {
            theRB.AddForce(Vector2.right * fireForce, ForceMode2D.Impulse);

           // Debug.Log("right");

        }

    }


    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCounter.ToString() + "KR";

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            directionCheck = true;

            Debug.Log("pressed left");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            directionCheck = false;
            Debug.Log("pressed right");

        }


        FireScript();

    }

    private void Awake()
    {
        // set the instance property/variable to this object
        instance = this;
    }


}
