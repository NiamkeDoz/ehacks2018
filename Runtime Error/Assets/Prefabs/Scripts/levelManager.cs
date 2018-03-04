using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class levelManager : MonoBehaviour {
	private PlayerController player;

	public GameObject currentCheckpoint;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RespawnPlayer(){
		Debug.Log ("Player Respawn");
//		Destroy (gameObject);
 		player.transform.position = currentCheckpoint.transform.position;
	}
}
