using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownShoot : ShootAI
{
    private Vector2 chosenAimDirection = new Vector2(1,0);
    private Vector2 playerPos;
    private bool playerDirection = false;
    public void Start()
    {
        playerPos = Object.FindObjectOfType<PlayerTank>().gameObject.transform.position;
    }
    public void Update() //Use this to decide where to aim
    {
        if (aimDirection == playerPos) { return; } //If already aiming at player
    }
    public override bool decideShoot()
    {
        GameObject hitting = Physics2D.Raycast(gameObject.transform.position, aimDirection).collider.gameObject;
        if (hitting.GetComponent<PlayerTank>() != null || hitting.GetComponent<Projectile>()!= null)
        {
            return true;
        }
        return false;
    }
}
