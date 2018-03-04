using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

    public float speed;

    private Transform player;
    private Vector2 target;


	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform; //grab the player object in the scene

        target = new Vector2(player.position.x, player.position.y); // target the players cordinates in the x, and y position

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //move the projectile at a speed towards the player

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }

	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player")) 
        {
            DestroyProjectile();
        }

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);

    }
}
