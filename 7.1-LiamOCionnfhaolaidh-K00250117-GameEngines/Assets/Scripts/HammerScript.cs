using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HammerScript : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float fireForce;
    public GameObject player;
    private Vector3 scaleHammer;

    public bool directionCheck;



    public void Fire()
    {




        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionCheck = true;



        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            directionCheck = false;


        }

        if (directionCheck == true)
        {
            theRB.AddForce(Vector2.left * fireForce, ForceMode2D.Impulse);
        }

        if (directionCheck == false)
        {
             theRB.AddForce(Vector2.right * fireForce, ForceMode2D.Impulse);
            
        }

    }
    void Update()
    {

      //  Fire();


    }
}
