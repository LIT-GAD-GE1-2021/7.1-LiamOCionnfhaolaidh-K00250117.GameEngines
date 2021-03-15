using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VikingController : MonoBehaviour
{
	public float maxSpeed = 10f;
	bool facingRight = true;
	bool Dodge;
	bool attack;
	float move;
	public Animator anim;

	public GameObject HammerSprite;

	Rigidbody2D rb;

	public float jumpforce = 700f;
	bool grounded = true;
	public Transform groundcheck;
	public LayerMask whatIsGround;



	public GameObject Hammer;
	public Transform hammerSpawn;
	private bool throwCheck = true;

	//public float jumpCount = 2;
	[Range(0, 2)] public float jumpCount;

	void Awake()
	{

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}


	private void Throw()
	{
	

		if (Input.GetKeyDown(KeyCode.V) == true && throwCheck == true)
		{

			GameObject theHammer;
			theHammer = Instantiate(Hammer, hammerSpawn.position, Quaternion.identity);


			HammerScript theHammerComponentScriptComponent = theHammer.GetComponent<HammerScript>();
			theHammerComponentScriptComponent.Fire();

			throwCheck = false;

		}

	}



	void FixedUpdate()
	{


		if (grounded == true)
        {
	      anim.SetFloat("RunTrigger", rb.velocity.y);
          anim.SetFloat("RunTrigger", Mathf.Abs(move));

        }
      


		if (move > 0 && !facingRight)
			Flip();
		else if (move < 0 && facingRight)
			Flip();

		move = Input.GetAxis("Horizontal");

		rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

		if (throwCheck == false)
        {

			maxSpeed = 20f;

        }

		else if (throwCheck == true)
        {
			maxSpeed = 10f;

        }


	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			grounded = true;

			anim.SetFloat("JumpFloat", 0);

			anim.SetBool("GroundBool", true);

			jumpCount += 2;

		}

		if (collision.gameObject.tag == "Hammer")
		{

			throwCheck = true;

			Destroy(collision.gameObject);

		}




	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			grounded = false;

	        anim.SetBool("GroundBool", false);

			anim.SetFloat("JumpFloat", rb.velocity.y);
		}
	}

	void Update()
	{

		Throw();


		if ((Input.GetKeyDown(KeyCode.Space) == true) && (jumpCount > 0))
		{

			jumpCount -= 1;

			rb.AddForce(new Vector2(0, jumpforce));

			grounded = false;
		    if (throwCheck == false)
            {
			jumpCount = 1;

            }


		}



		if (grounded == false)
		{
		     anim.SetFloat("JumpFloat", rb.velocity.y);

		}
	}

	void Flip()
	{

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;

		theScale.x *= -1;

		transform.localScale = theScale;

	}





}
