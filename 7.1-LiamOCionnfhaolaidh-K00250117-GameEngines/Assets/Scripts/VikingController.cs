using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class VikingController : MonoBehaviour
{
	
	
	public GameObject Hammer;
	public SpriteRenderer hammerSprite;
	public SpriteRenderer playerSprite;

	public Transform hammerSpawn;

	private bool haveTheHammer = true;
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

	public bool touchingTheHammer;
	private bool playerIsDead = false;
	[Range(0, 3)] public float healthNumber;


	private void Throw()
	{
	

		if (Input.GetKeyDown(KeyCode.V) == true && haveTheHammer == true)
		{

			GameObject theHammer;
			theHammer = Instantiate(Hammer, hammerSpawn.position, hammerSpawn.rotation);
			theHammer.transform.right = transform.right.normalized;

			haveTheHammer = false;

		    hammerSprite.GetComponent<SpriteRenderer>();
			hammerSprite.enabled = false;


		}



		if (Input.GetKeyDown(KeyCode.V) == true && haveTheHammer == false)
        {
			touchingTheHammer = true;
		}


		if (Input.GetKeyUp(KeyCode.V) == true)
		{
			touchingTheHammer = false;
		}


	}

	private void JumpCountControl()
    {
		if (jumpCount > 2)
        {
			jumpCount = 2;

        }

		if (haveTheHammer == false)
		{

			if (jumpCount > 1)
			{
				jumpCount = 1;

			}



		}



	}

	void FixedUpdate()
	{

		if (grounded == true)
        {
	      anim.SetFloat("RunTrigger", rb.velocity.y);
          anim.SetFloat("RunTrigger", Mathf.Abs(move));

        }
      
      if (playerIsDead == false)
        {
		  if (move > 0 && !facingRight)
			Flip();
		  else if (move < 0 && facingRight)
			Flip();

		  move = Input.GetAxis("Horizontal");

		  rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);



        }


		
		
		if (haveTheHammer == false)
        {
			maxSpeed = 20f;
        }

		else if (haveTheHammer == true)
        {
			maxSpeed = 10f;

        }


	}

	public void CheckHealth()
    {

		if (healthNumber >= 3)
        {

			LevelManagerScript.instance.BackToLife();

		}

		if (healthNumber == 2)
        {
			
			LevelManagerScript.instance.TakeDamage1();


		}

		if (healthNumber == 1)
		{

			LevelManagerScript.instance.TakeMoreDamage();


		}

		if (healthNumber <= 0)
        {

			LevelManagerScript.instance.TakeEvenMoreDamage();
			playerIsDead = true;

		}
		

	}




	public void ReturnFromDeath()
	{

		if (LevelManagerScript.instance.bringThePlayerBack == true)

		{
		  //  healthNumber = 3;
			playerIsDead = false;
			anim.SetBool("PlayerHasDied", false);
			hammerSprite.GetComponent<SpriteRenderer>();
			hammerSprite.enabled = true;

		}

		if (LevelManagerScript.instance.bringThePlayerBack == true && Input.GetKeyDown(KeyCode.Y))
		{
			healthNumber = 3;


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

			if (touchingTheHammer == true)
			{
			    haveTheHammer = true;

			    Destroy(collision.gameObject);

			    hammerSprite.GetComponent<SpriteRenderer>();
			    hammerSprite.enabled = true;



			}

		}



		if (collision.gameObject.tag == "Enemy")
		{
			healthNumber -= 1;

			StartCoroutine("ColorChange");

		}

		if (collision.gameObject.tag == "ValkyrieBuck")
		{
			
			LevelManagerScript.instance.VBuckCollect();
			Destroy(collision.gameObject);

		}

	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Coin")
		{
			LevelManagerScript.instance.KronerCollect();

			Destroy(collision.gameObject);

		}


	}

	IEnumerator ColorChange()
	{

		playerSprite.material.SetColor("_Color", Color.red);

		yield return new WaitForSeconds(0.3f);

		playerSprite.material.SetColor("_Color", Color.white);


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

		CheckHealth();
		Throw();
		JumpCountControl();
		ReturnFromDeath();


		if ((Input.GetKeyDown(KeyCode.Space) == true) && (jumpCount > 0) && playerIsDead == false)
		  {

			  jumpCount -= 1;

			  rb.AddForce(new Vector2(0, jumpforce));

			  grounded = false;

		      if (haveTheHammer == false)
                 {

			           jumpCount = 1;
				       jumpCount -= 1;


			     }


           }
		
		if (healthNumber < 0)
        {

			healthNumber = 0;

        }

		if (playerIsDead == true)
        {

			anim.SetBool("PlayerHasDied", true);
			hammerSprite.GetComponent<SpriteRenderer>();
			hammerSprite.enabled = false;

		}

		if (grounded == false)
		{
		     anim.SetFloat("JumpFloat", rb.velocity.y);

		}
	}

	void Flip()
	{

		facingRight = !facingRight;

		transform.Rotate(0f, 180f, 0f);

	}

	void Awake()
	{

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}





}
