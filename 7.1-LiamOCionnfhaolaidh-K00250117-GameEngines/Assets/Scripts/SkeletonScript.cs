using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{

    public Rigidbody2D enemyRB;
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        enemyRB.velocity = Vector2.left * speed;
        Vector3 theScale = transform.localScale;
        theScale.x = 0.5026802f;
        transform.localScale = theScale;



    }
}
