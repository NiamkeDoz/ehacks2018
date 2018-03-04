using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGameObjectRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		//rotate the current item
		this.transform.Rotate(0, 0, 5f);
	}
}
