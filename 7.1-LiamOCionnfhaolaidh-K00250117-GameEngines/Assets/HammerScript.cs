using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float fireForce;

    public void Fire()
    {

        theRB.AddForce(Vector2.right * fireForce, ForceMode2D.Impulse);

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
