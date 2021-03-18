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



        if (directionCheck == true)
        {


            theRB.AddForce(Vector2.left * (fireForce * -1), ForceMode2D.Impulse);

            Debug.Log("left");
        }

        if (directionCheck == false)
        {
             theRB.AddForce(Vector2.right * fireForce, ForceMode2D.Impulse);

            Debug.Log("right");

        }

    }
    void Update()
    {


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
