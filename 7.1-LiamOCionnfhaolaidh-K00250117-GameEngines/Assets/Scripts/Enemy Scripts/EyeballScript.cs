using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballScript : MonoBehaviour
{

    public Rigidbody2D eyeRB;
    public float speed;


    public void GoLeft()
    {

        eyeRB.velocity = Vector2.left * speed;
        Vector3 theScale = transform.localScale;
        theScale.x = -0.7433314f;
        transform.localScale = theScale;


    }

    public void GoRight()
    {
        eyeRB.velocity = Vector2.right * speed;
        Vector3 theScale = transform.localScale;
        theScale.x = 0.7433314f;
        transform.localScale = theScale;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {

            Destroy(gameObject);

        }
    }



}
