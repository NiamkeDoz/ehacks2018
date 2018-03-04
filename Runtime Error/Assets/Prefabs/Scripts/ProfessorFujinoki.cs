using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessorFujinoki : MonoBehaviour  {

    //this reference is given major credit for the development finite state machine https://pastebin.com/d1WERL5v
	public GameObject playerReference;
    private Transform player; // player
    public GameObject projectile; //projectile

    private float timeBetweenShots;
    public float startTimeBetweenShots;


    public float detectRange = 8f;      // Maximum range at which to target and chase the player
    public float attackRange = 4f;      // Maximum range at which to fire straight forward

    public float targetDistance = 2f;   // Maximum approach distance to target
    public float moveSpeed = 0.02f;     // Movement speed
    public float turnSpeed = 0.05f;		// Turn rate

    public float maxIdleTime = 1f;      // Maximum time waiting before searching around for player
    public float randomRoamDistance = 10f;  // Maximum distance at which to target a new location

	private Vector3 pos1 = new Vector3 (10, 8, 0);
	private Vector3 pos2 = new Vector3 (80, 8, 0);
	public float speed = 1.0f;

    // AI State Variables
    Quaternion desiredRotation;
    Vector3 lastKnownLocation;
    float cooldownTime = 0f;
    float idleTime = 0f;
    bool moved = false;

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
	{
        

       
		transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong (Time.time * moveSpeed, 1.0f));
		// We are close enough to fire! Shoot straight ahead!

		// We can fire again
            
		if (timeBetweenShots <= 0) {
			Instantiate (projectile, transform.position, Quaternion.identity); // spawn the projectile
			timeBetweenShots = startTimeBetweenShots; //only spawn 1 projectile, otherwise it will spawn 60 projectiles per second
		} else {
			timeBetweenShots -= Time.deltaTime;
		}

            
        
    
	}       
    
}
