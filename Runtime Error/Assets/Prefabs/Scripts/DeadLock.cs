using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLock : MonoBehaviour
{

    private Transform player; // player
    public GameObject projectile; //projectile

    private float timeBetweenShots;
    public float startTimeBetweenShots;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;

    }

    // Update is called once per frame
    void Update()
    {

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity); // spawn the projectile
            timeBetweenShots = startTimeBetweenShots; //only spawn 1 projectile, otherwise it will spawn 60 projectiles per second
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

    }


}
