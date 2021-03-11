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

	public GameObject Hammer;
	public GameObject hammerSpawn;

	public GameObject HammerSprite;




	Rigidbody2D rb;


	public float jumpforce = 700f;
	bool grounded = true;
	public Transform groundcheck;

	public LayerMask whatIsGround;


	void Awake()
	{

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}


	private void Shoot()
	{
	

		if (Input.GetKeyDown(KeyCode.V) == true)
		{

			GameObject theHammer;
			theHammer = Instantiate(Hammer, hammerSpawn.position, Quaternion.identity);


			HammerScript theHammerComponentScriptComponent = theHammer.GetComponent<HammerScript>();
			theHammerComponentScriptComponent.Fire();
			

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


	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Floor")
		{
			grounded = true;

			anim.SetFloat("JumpFloat", 0);

			anim.SetBool("GroundBool", true);

		}


	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Floor")
		{
			grounded = false;



	        anim.SetBool("GroundBool", false);

			anim.SetFloat("JumpFloat", rb.velocity.y);
		}
	}

	void Update()
	{

		if ((Input.GetKeyDown(KeyCode.Space) == true) && grounded == true)
		{
		

			rb.AddForce(new Vector2(0, jumpforce));

			grounded = false;



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
