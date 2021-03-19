using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HammerScript : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float fireForce;
    public float minusFireForce = -5;

    public Transform scaleTransform;

    public bool directionCheck;

    void Start()
    {
        LevelManagerScript.instance.FireScript();

    }

    public void Fire()
    {

        LevelManagerScript.instance.FireScript();

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





    void Update()
    {
       // Fire();

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

    }
}
