using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{

    public Rigidbody2D enemyRB;
    public float speed;
    public Animator skeleAnim;

    public bool attackCheck;

    public Transform detectRay;
    public float detectDistance = 4.0f;

    public bool drawRay = false;

    public float enemyHealth = 3;

    public SpriteRenderer enemySprite;

    public void AttackOver()
    {
        skeleAnim.SetBool("AttackBool", false);
        speed = 2;
       // Debug.Log("Attack Has Finished");

        attackCheck = false;

    }

    public void DetectPlayer()
    {

        Vector2 rayDirection = Vector2.left * transform.localScale.x;

        Physics2D.queriesStartInColliders = false;

        RaycastHit2D rayHit;
        rayHit = Physics2D.Raycast(detectRay.position, rayDirection, detectDistance);

        if (rayHit.collider != null)
        {
            speed = 0;
            skeleAnim.SetBool("AttackBool", true);
           // Debug.Log("Hit Something");

            //GetComponent<BoxCollider2D>() = new Vector2(10f, 0.5f);


        }


    }

    IEnumerator ColorChange()
    {

            enemySprite.material.SetColor("_Color", Color.red);

            yield return new WaitForSeconds(0.1f);

            enemySprite.material.SetColor("_Color", Color.white);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {

            enemyHealth -= 1;

            StartCoroutine("ColorChange");

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {


            //do nothing

        }
    }





    public void onDrawGizmos()
    {
        if (drawRay == true)
        {
            Gizmos.color = Color.green;

            Vector2 rayStartPosition = detectRay.position;
            Vector2 rayDirection = Vector2.left * transform.localScale.x;

            Gizmos.DrawLine(rayStartPosition, rayStartPosition + (rayDirection * detectDistance));

        }


    }


    // Update is called once per frame
    void Update()
    {
        onDrawGizmos();
        DetectPlayer();


        enemyRB.velocity = Vector2.left * speed;
        Vector3 theScale = transform.localScale;
        theScale.x = 0.5026802f;
        transform.localScale = theScale;

        if (enemyHealth == 0)
        {

            Destroy(gameObject);

        }



    }
}
