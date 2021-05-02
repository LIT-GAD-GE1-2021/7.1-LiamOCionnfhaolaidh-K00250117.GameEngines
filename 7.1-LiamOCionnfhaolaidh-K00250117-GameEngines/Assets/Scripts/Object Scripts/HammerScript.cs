using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float speed = 10f;

    public AudioSource enemyHit;

    void Start()
    {

        theRB.velocity = transform.right * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHit.Play();

        }

    }
 }