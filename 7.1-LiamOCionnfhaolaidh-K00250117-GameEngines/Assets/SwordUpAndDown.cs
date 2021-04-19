using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUpAndDown : MonoBehaviour
{


    public Rigidbody2D swordRB;
    public float speed;

    public void GoUp()
    {

        swordRB.velocity = Vector2.up * speed;
        Vector3 theScale = transform.localScale;

        transform.localScale = theScale;


    }

    public void GoDown()
    {
        swordRB.velocity = Vector2.down * speed;
        Vector3 theScale = transform.localScale;

        transform.localScale = theScale;


    }

}
