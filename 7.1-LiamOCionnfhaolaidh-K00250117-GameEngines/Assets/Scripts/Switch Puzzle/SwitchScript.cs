using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{

    public Animator anim;
    public Collider2D BrownDoor;
    public SpriteRenderer doorSprite;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            anim.SetBool("PlayerContact", true);

            BrownDoor.GetComponent<BoxCollider2D>();
            BrownDoor.enabled = false;

            doorSprite.GetComponent<SpriteRenderer>();
            doorSprite.enabled = false;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            anim.SetBool("PlayerContact", false);
            BrownDoor.enabled = true;


            doorSprite.enabled = true;
        }

    }

}
