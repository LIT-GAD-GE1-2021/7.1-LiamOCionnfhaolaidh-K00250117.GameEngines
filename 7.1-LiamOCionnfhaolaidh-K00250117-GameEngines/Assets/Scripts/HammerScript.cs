using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HammerScript : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float fireForce;

    public float speed = 10f;

    public Transform scaleTransform;

    public bool directionCheck;


    void Start()
    {
        //nithing

        theRB.velocity = transform.right * speed;


    }

 
}