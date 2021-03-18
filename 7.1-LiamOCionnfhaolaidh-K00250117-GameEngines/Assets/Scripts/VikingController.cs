using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class VikingController : MonoBehaviour
{
	
	
	public GameObject Hammer;
	public SpriteRenderer hammerSprite;
	public Transform hammerSpawn;

	private bool throwCheck = true;
	[Range(0, 2)] public float jumpCount;


	Rigidbody2D rb;

	public float jumpforce = 700f;
	bool grounded = true;
	public Transform groundcheck;
	public LayerMask whatIsGround;

	public float maxSpeed = 10f;

	bool Dodge;
	bool attack;
	float move;
	public Animator anim;


	public Transform playerTransaform;
	private Vector3 scalePlayer;
	public bool facingRight = true;
	public bool checkCheck;



	private void Throw()
	{
	

		if (Input.GetKeyDown(KeyCode.V) == true && throwCheck == true)
		{

			GameObject theHammer;
			theHammer = Instantiate(Hammer, hammerSpawn.position, Quaternion.identity);
			theHammer.transform.right = transform.right.normalized;

			HammerScript theHammerComponentScriptComponent = theHammer.GetComponent<HammerScript>();
			theHammerComponentScriptComponent.Fire();

			throwCheck = false;



		    hammerSprite.GetComponent<SpriteRenderer>();
			hammerSprite.enabled = false;


			Debug.Log("FIRE");

		}

	}

	private void JumpCountControl()
    {
		if (jumpCount > 2)
        {
			jumpCount = 2;

        }

		if (throwCheck == false)
		{

			if (jumpCount > 1)
			{
				jumpCount = 1;

			}



		}



	}

	void FixedUpdate()
	{
		if (scalePlayer.x == 0.4)

		{

			facingRight = true;

			checkCheck = true;


		}

		if (scalePlayer.x == -0.4)

		{

			facingRight = false;
			checkCheck = false;


		}


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

			hammerSprite.GetComponent<SpriteRenderer>();
			hammerSprite.enabled = true;

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
		if (scalePlayer.x == 0.4)

		{

			facingRight = true;

			checkCheck = true;


		}

		if (scalePlayer.x == -0.4)

		{

			facingRight = false;
			checkCheck = false;


		}

		Throw();
		JumpCountControl();

		if ((Input.GetKeyDown(KeyCode.Space) == true) && (jumpCount > 0))
		{

			jumpCount -= 1;

			rb.AddForce(new Vector2(0, jumpforce));

			grounded = false;

		    if (throwCheck == false)
            {

			   jumpCount = 1;
				jumpCount -= 1;


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

	void Awake()
	{

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}





}
