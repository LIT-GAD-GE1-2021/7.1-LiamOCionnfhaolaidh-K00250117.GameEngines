using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public Animator anim;
    public Collider2D Door;
    public Animator doorAnim;
    public Collider2D DoorCollide;

    public AudioSource doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hammer")
        {

            anim.SetBool("TurnGreen", true);
            doorAnim.SetBool("OpenTheDoor", true);

            doorOpen.Play();

            DoorCollide.GetComponent<BoxCollider2D>();
            DoorCollide.enabled = false;

        }


    }


}
