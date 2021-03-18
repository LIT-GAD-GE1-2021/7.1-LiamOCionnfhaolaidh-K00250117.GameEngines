using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float fireForce;

    public bool directionCheck;


    public void Fire()
    {

        if (directionCheck == true)
        {
            theRB.AddForce(Vector2.left * fireForce, ForceMode2D.Impulse);
        }

        else if (directionCheck == false)
        {
            if (directionCheck == false)
            {
                theRB.AddForce(Vector2.right * fireForce, ForceMode2D.Impulse);
            }
        }


    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directionCheck = true;


        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            directionCheck = false;


        }



    }
}
