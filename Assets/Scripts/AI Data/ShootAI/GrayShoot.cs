using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayShoot : ShootAI
{
    public void Start()
    {
        initRotate();
        player = Object.FindObjectOfType<PlayerTank>().gameObject;// Identify the player object
        //chosenAimDirection = Random.insideUnitCircle.normalized; //Select a random future direction
    }

    public void Update()
    {
        Vector2 position2d = transform.position;
        Vector2 playerPos2d = player.transform.position;
        aimDirection = (playerPos2d - position2d).normalized;
        hitObject = Physics2D.Raycast(position2d+aimDirection, aimDirection).collider.gameObject; //Calculate what this is aiming at
        RotateGun();
        Debug.Log(hitObject);
        Debug.Log("Update!");
    }
    public override bool DecideShoot()
    {
        Debug.Log(hitObject == player);
        if (hitObject == player) {
            return true;
        }
        return false;
    }
}
