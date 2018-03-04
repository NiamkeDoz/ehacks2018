using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

	public bool hasDied;
	public int health;
	public int minDeathHeight = -7;
	public Collider2D other;

	// Use this for initialization
	void Start () {
		hasDied = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < minDeathHeight) {
			hasDied = true;


		}

			

		if (hasDied == true) {
			Die ();
		}
	}

	void Die(){
		SceneManager.LoadScene ("MainScene");

	}
}
