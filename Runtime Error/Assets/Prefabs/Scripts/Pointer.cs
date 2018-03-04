using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pointer : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float bufferDistance; //might need this because player will die instantly the enemy moves at .0000...1 distance
    public float retreatDistance;
    public Rigidbody2D rb2dEnemy; //this gets the component, pointer, to rotate it x amount of degrees

    public Transform player;
    private Vector2 target;

    private Transform enemy;
    private Vector2 charger; //the pointer enemy that will charge the target, which is the player


    //math variables to calculate the angle to move //
    private float slope; //y = mx + b
    private float b;
    private float angle;

    // variables for calculating the angle //
        //circle point x = point below 180 degrees, dont want this one
        //circle point y = point above 180 degrees, which is the point that you always want to get
    private float cPx;
    private float cPy;

    // Ax^2 + Bx + C = 0 where you find A, B, C, which is dervied from the calculating the radius of a circle, given its radius is 1
    // circle equation (x - enemy.position.x)^2 + (y - enemy.position.y)^2 = 1
    private float A;
    private float B;
    private float C;

    // Use this for initialization

    public GameObject target2;
    public float rotationSpeed;


    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
   
        target = new Vector2(player.position.x, player.position.y);

        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        charger = new Vector2(enemy.position.x, enemy.position.y);
        rb2dEnemy = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        

        //calculate the slope to get the B 
        slope = ((enemy.position.y - player.position.y) / (enemy.position.x - player.position.x));

        b = (enemy.position.y - (enemy.position.x * slope));


        if ( (Vector2.Distance(transform.position, player.position) > stoppingDistance) )
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            
            Vector3 vectorToTarget = target2.transform.position - transform.position; //gets the line from the enemy position to the player position
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion qt = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * rotationSpeed);


        }

        //if the enemys position is == to the players position, then move an extra x amount of units away from the plauyer before switching directions
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

       else if (Vector2.Distance(transform.position, player.position) == stoppingDistance)
        {
            transform.Rotate(Vector2.right, Time.deltaTime);
            transform.Rotate(Vector2.up, Time.deltaTime);
        }

      


	}



    double calculateAngle()
    {
        // the point thats below 180 degrees
      


        //if the player jumps, check to see  if x positions are the same, points straight up
        if (player.position.x == enemy.position.x)
        {
            angle = Mathf.PI / 2; //returns 90 degrees or pi/2
        }

        //arrow points left
        else if ( (player.position.y == enemy.position.y) && (player.position.x < enemy.position.x))
        {
            angle = 0; 
        }

        //arrow points right
        else if ( (player.position.y == enemy.position.y) && (player.position.x < enemy.position.x) )
        {
            angle = Mathf.PI;
        }
        else
        {
            A = 1 + (slope * slope);
            B = (2 * slope * b) - (2 * slope * enemy.position.y); //b =  value in mx + b, B = Bx from quadratic equation
            C = ((enemy.position.x) * (enemy.position.x)) - (enemy.position.x) - (enemy.position.x) - (2 * b * enemy.position.y) + ((enemy.position.y) * (enemy.position.y)) + (b * b) - 1;

            //how to find x using quadratic formula, D is under the sqrt
            float D = (B * B) - (4 * A * C);

            float x1 = (0 - B + Mathf.Sqrt(D)) / (2 * A);
            float x2 = (0 - B - Mathf.Sqrt(D)) / (2 * A);

            float y1 = (slope * x1) + b;
            float y2 = (slope * x2) + b;

            if(y1 > enemy.position.y)
            {
                cPx = x1;
                cPy = y1;
            }

            else
            {
                cPx = x2;
                cPy = y2;
            }

            //opposite distance is the other side of the triangl
            float oppositeDistance = cPy - enemy.position.y;

            //adjacentdistance is to the left of the angle, inside the triangle
            float adjacentDistance = enemy.position.x - cPx;

            if(cPx > enemy.position.x)
            {
                adjacentDistance = 0 - adjacentDistance;
                float tangent = oppositeDistance / adjacentDistance;
                angle = Mathf.Tan(tangent);
            }

            if(player.position.x > enemy.position.x)
            {
                angle = Mathf.PI - angle;
            }


        }
        return angle;
    }
}
