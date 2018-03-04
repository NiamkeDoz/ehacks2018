using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start()
	{

		myRigidbody = GetComponent<Rigidbody2D>();
		myRigidbody.velocity = new Vector2(0, 0);

	}

	// Update is called once per frame
	void Update()
	{

		

		// if the left arrow key is pressed:
		//if (Input.GetKeyDown(KeyCode.LeftArrow))
		//{

		//	// keep velocity set to this constant value
		//	myRigidbody.velocity = new Vector2(-moveSpeed, myRigidbody.velocity.y);

		//}
		//if (Input.GetKeyDown(KeyCode.RightArrow))
		//{

		myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

		//}
		// we're not pressing left or right! character moves automatically
		if (Input.GetKeyDown(KeyCode.Space))
		{

			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);

		}

	}
}