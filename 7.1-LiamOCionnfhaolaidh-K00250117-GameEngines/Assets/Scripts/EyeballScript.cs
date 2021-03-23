using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballScript : MonoBehaviour
{

    public float timeRemaining = 2;
    public Rigidbody2D eyeRB;
    public float speed;
 

    IEnumerator ChangeDirection()
    {
        
        yield return new WaitForSeconds(0.5f);

        eyeRB.velocity = Vector2.left * speed;

        Vector3 theScale = transform.localScale;
        theScale.x = -0.7433314f;
        transform.localScale = theScale;

        StartCoroutine("ChangeAgain");

    }

    IEnumerator ChangeAgain()
    {
        yield return new WaitForSeconds(0.5f);

        eyeRB.velocity = Vector2.right * speed;

        Vector3 theScale = transform.localScale;
        theScale.x = 0.7433314f;
        transform.localScale = theScale;


    }

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


    public void MoveLeftAndRight()
    {
        if (timeRemaining <= 2)
        {
            timeRemaining -= Time.deltaTime;
            eyeRB.velocity = Vector2.right * speed;
            Vector3 theScale = transform.localScale;
            theScale.x = 0.7433314f; 
            transform.localScale = theScale;

        }
        if (timeRemaining <= 1 && timeRemaining >= 0)
        {
            eyeRB.velocity = Vector2.left * speed;
            Vector3 theScale = transform.localScale;
            theScale.x = -0.7433314f; 
            transform.localScale = theScale;

        }
        if (timeRemaining <= 0)
        {
            timeRemaining = 2;

        }


    }


    void Update()
    {

        // StartCoroutine("ChangeDirection");

       // MoveLeftAndRight();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {

            Destroy(gameObject);

        }
    }



}
