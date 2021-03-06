using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootAI
{
    public void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 aimDirection3 = (mousePos - transform.position).normalized;
        aimDirection = aimDirection3;
        RotateGun();
    }
    public override bool DecideShoot()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0)) { 
            return false;
        }
        return true;
    }
}
