using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer2 : MonoBehaviour {

	[SerializeField]Transform spawnPoint;
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.transform.CompareTag ("Player")) {
			coll.transform.position = spawnPoint.position;
		}
	}
}
