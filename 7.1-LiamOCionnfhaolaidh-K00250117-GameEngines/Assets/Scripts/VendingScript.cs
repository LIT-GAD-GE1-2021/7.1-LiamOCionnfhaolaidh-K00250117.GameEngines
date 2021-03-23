using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingScript : MonoBehaviour
{
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
        if (collision.gameObject.tag == "Player")
        {
            
            if (Input.GetKeyDown(KeyCode.B) == true)
            {
               
                LevelManagerScript.instance.SpendMoney();


            }

            Debug.Log("Triggered collider");
        }
    }




}
