using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Projectile projectileType;
    public float fireSpeed;
    public int numberOfProjectileBounces;

    public int bulletLimit;
    public ShootAI shootAI;
    [HideInInspector]
    public Vector2 aimDirection;

    public List<Projectile> bullets;
    private float fireTimer = 0;
    public void Update()
    {
        aimDirection = shootAI.aimDirection;
        fireTimer -= Time.deltaTime;
        bool shouldShoot = shootAI.decideShoot(); //Aims the gun wherever it needs to be, returns bool that says whether you actually should.
        if (shouldShoot && fireTimer <=0 && bullets.Count < bulletLimit) //If you should shoot, and your fire rate allows it, and your active bullet limit allows it...
        {
            Fire(); //FIRE!
        }
    }
    public void Fire()
    {
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg; //Need angle to calculate Quaternion
        Quaternion rotation = Quaternion.Euler(0, 0, angle - 90); //Calculate quaternion to create bullet at proper angle
        Vector3 aimDirection3 = new Vector3(aimDirection.x, aimDirection.y); //Need vector3, not 2, to create bullet
        Projectile projec = Instantiate(projectileType, transform.position + aimDirection3, rotation); //Create bullet at proper location and quaternion
        bullets.Add(projec); //Add the bullet to this tank's list of existing bullets
        projec.direction = aimDirection; //Direction is needed for bullet to go correct way
        projec.bounces = numberOfProjectileBounces; //Set the remaining bullet's bounces to this turret shooter's maximum
        projec.creator = this;
        fireTimer = fireSpeed; //Reset firespeed timer
    }
}
