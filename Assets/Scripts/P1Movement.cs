using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class P1Movement : MonoBehaviour
{
	// Components
	BoxCollider2D jumpBox;
	P1JumpBoxManager jbm;
	Rigidbody2D rb;

	// Left Right Movement Variables
	public float playerMoveSpeed;

	// Jump Variables
	public float jumpForce;
	public float fastFallMod = 1.5f;

	// Set up Internal Variables
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Set up External Variables
	void Start()
	{
		jumpBox = GameObject.Find("p1JumpBox").GetComponent<BoxCollider2D>();
		jbm = jumpBox.GetComponent<P1JumpBoxManager>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.A))
			rb.velocity = new Vector2(-playerMoveSpeed, rb.velocity.y);
		else if (Input.GetKey(KeyCode.D))
			rb.velocity = new Vector2(playerMoveSpeed, rb.velocity.y);
		else 
			rb.velocity = new Vector2(0.0f, rb.velocity.y);
		
		if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.W))
		{
			if (jbm.CanJump)
			{
				rb.velocity += new Vector2(0.0f, jumpForce);
			}
		}

		if (rb.velocity.y < 0.0f)
			rb.velocity += new Vector2(0.0f, Physics2D.gravity.y * fastFallMod * Time.deltaTime);
	}
}
