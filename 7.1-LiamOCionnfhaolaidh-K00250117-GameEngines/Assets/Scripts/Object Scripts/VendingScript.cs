using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingScript : MonoBehaviour
{

    public GameObject newHammer;
    public Transform hammerSpawn;
    public SpriteRenderer textSprite;

    public bool buttonCheck;
    public bool findTheHammer;


    private void Awake()
    {

        textSprite.GetComponent<SpriteRenderer>();
        textSprite.enabled = false;

    }


    void Update()
    {

        if (GameObject.Find("Hammer(Clone)") != null)
        {
            findTheHammer = true;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) == true && buttonCheck == true && findTheHammer == true)
            {
                LevelManagerScript.instance.SpendMoney();

                if (LevelManagerScript.instance.moneyCheck == true)
                {

                  GameObject theHammer;
                  theHammer = Instantiate(newHammer, hammerSpawn.position, hammerSpawn.rotation);
                  theHammer.transform.right = transform.right.normalized;

                   Destroy(GameObject.FindWithTag("Hammer"));

                }

            }



    }

    private void OnTriggerEnter2D(Collider2D collis)
    {
        if (collis.gameObject.tag == "Player")
        {

            buttonCheck = true;
            Debug.Log("Triggered collider");

            textSprite.GetComponent<SpriteRenderer>();
            textSprite.enabled = true;


        }
    }

    private void OnTriggerExit2D(Collider2D collis)
    {
        if (collis.gameObject.tag == "Player")
        {


            textSprite.GetComponent<SpriteRenderer>();
            textSprite.enabled = false;


        }
    }


}
