using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownShoot : ShootAI
{
    
    public void Start()
    {
        initRotate();
        player = Object.FindObjectOfType<PlayerTank>().gameObject;// Identify the player object
        chosenAimDirection = Random.insideUnitCircle.normalized; //Select a random future direction
    }
    public void Update() //Use this to decide where to aim
    {
        //playerDirection = (player.transform.position - transform.position); //Calculate the line to the player
        Vector2 position2d = gameObject.transform.position;
        hitObject = Physics2D.Raycast(position2d+aimDirection, aimDirection).collider.gameObject; //Calculate what this is aiming at
        //Debug.Log(hitObject);
        if (hitObject == player) //If this has a direct line of sight to the player or a bullet to shoot
        {
            chooseDirectionTimer = 1;
            return; //Will not aim in any other direction
        } else if (aimDirection != chosenAimDirection && chooseDirectionTimer <= 0) //If this hasn't yet moved its thing to the chosen random direction, and it is time to start moving
        {
            float aimAngle = Vector2.Angle(new Vector2(1, 0), aimDirection);
            if (aimDirection.y < 0) { aimAngle = 360 - aimAngle; }
            float chosenAngle = Vector2.Angle(new Vector2(1, 0), chosenAimDirection);
            if (chosenAimDirection.y < 0) { chosenAngle = 360 - chosenAngle; }
            aimAngle += Mathf.Clamp(chosenAngle - aimAngle, -120*Time.deltaTime, 120*Time.deltaTime);
            aimDirection.x = Mathf.Cos(aimAngle*Mathf.Deg2Rad);
            aimDirection.y = Mathf.Sin(aimAngle*Mathf.Deg2Rad); //Move the turret towards the new direction
            RotateGun();
            if (Mathf.Abs(aimAngle - chosenAngle) < 0.0001) //If it has now been aimed to the chosen direction
            {
                chosenAimDirection = Random.insideUnitCircle.normalized; //Select a random future direction
                chooseDirectionTimer = Random.value * 2; //Choose a random amount of time
            }
        }
        chooseDirectionTimer -= Time.deltaTime;
    }
    public override bool DecideShoot()
    {
        //GameObject hitting = Physics2D.Raycast(gameObject.transform.position, aimDirection).collider.gameObject;
        if (hitObject == player)
        {
            return true;
        }
        return false;
    }
}
