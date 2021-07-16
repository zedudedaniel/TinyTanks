using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TealMovement : MovementAI
{
    private Vector2 chosenDirection;
    private float chooseDirectionTimer = 0;
    private float moveTimer;
    //private Vector2[] directions = new Vector2[8]; //The eight directions the tank could move
    private int direction;
    private Vector2[] directionArray = new Vector2[8] {
        new Vector2(1, 0),
        new Vector2(1, 1).normalized,
        new Vector2(0, 1),
        new Vector2(-1, 1).normalized,
        new Vector2(-1, 0),
        new Vector2(-1, -1).normalized,
        new Vector2(0, -1),
        new Vector2(1, -1).normalized
    };
    //private bool awoke = false;
    public void Awake()
    {
    }
    public void Start()
    {
        direction = Random.Range(0, 8); //Used as ID for direction array
        moveTimer = Random.Range(1, 9); //Move in the first direction for 1-8 seconds
    }
    public override Vector2 decideMovement()
    { 
        if (chooseDirectionTimer > 0) //If you've decided to wait before moving...
        {
            chooseDirectionTimer -= Time.deltaTime;
            return new Vector2(0, 0); //Stay still and count down your timer to start moving
        }
        else //If the timer says to move
        {
            Vector2 pos;
            pos.x = transform.position.x;
            pos.y = transform.position.y; //Needed to translate Vector3 into Vector2
            if (moveTimer <= 0 || Physics2D.Raycast(pos, pos + directionArray[direction], 1f)) //If it's time to stop, or there's something in the way
            {
                chooseDirectionTimer = Random.Range(1, 3);
                direction = Random.Range(0, 8);
                moveTimer = Random.Range(1, 9);
                return new Vector2(0, 0);
            }
            else //If we're all good to move
            {
                return directionArray[direction];
            }
        }
    }
}
