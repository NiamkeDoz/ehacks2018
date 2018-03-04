using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

		// keep velocity set to this constant value
		myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

		// if the spacebar is pressed, or the left mouse button is pressed
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{

			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);

		}

	}
}
