using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TealMovement : MovementAI
{
    private Vector2 chosenDirection;
    private float chooseDirection = 1;
    private Vector2[] directions = new Vector2[8]; //The eight directions the tank could move
    public void Start()
    {
        int addConst = 0;
        for(int i = -1; i < 2; i++) {
            for(int j = -1; j < 2; j++) { //Each of 8 directions, add to the thing
                if (i == 0 && j ==0) {
                addConst = -1;
                continue;
                }
                directions[i+j+2+addConst] = new Vector2(i,j);
            }
        }
        chosenDirection = directions[Random.Range(0, 8)];
    }
    public override Vector2 decideMovement()
    {
        Debug.Log(Physics2D.Raycast(transform.position, chosenDirection, 0.8f).collider.gameObject.GetComponent<Wall>());
        Debug.Log(chosenDirection);
        if (chosenDirection == new Vector2 (0,0) || chooseDirection <= 0 || Physics2D.Raycast(transform.position, chosenDirection, 1).collider.gameObject.GetComponent<Wall>() != null)
        { //If the timer ran out, or there's a wall in the way, it's time to choose a new direction
            List<Vector2> possMoves = new List<Vector2>();
            for(int i = 0; i < 8; i++)
            {
                if (chosenDirection != directions[i] && Physics2D.Raycast(transform.position, directions[i], 1).collider.gameObject.GetComponent<Wall>() != null)
                { //If this direction is a legal move
                    possMoves.Add(directions[i]); //Add it to the randomly selected pool of chosen directions
                }
            }
            if (possMoves.Count > 0) { //If there are legal moves
                chosenDirection = directions[Random.Range(0, possMoves.Count)];
                chooseDirection = Random.Range(0.5f, 3f);
            } else { //If there are no equal moves
                chosenDirection = new Vector2(0,0);
            }
        }
        chooseDirection -= Time.deltaTime;
        //Debug.Log(chosenDirection);
        return chosenDirection;
    }
}
