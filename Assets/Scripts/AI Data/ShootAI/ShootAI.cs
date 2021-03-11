using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootAI : MonoBehaviour
{
    public GameObject gunRotator;
    [HideInInspector]
    public Vector2 aimDirection;
    public Vector2 chosenAimDirection;
    public GameObject player;
    public GameObject hitObject;
    public float chooseDirectionTimer = 0;

    public virtual bool DecideShoot()
    {
        return false;
    }
    public virtual void RotateGun()
    {
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        gunRotator.transform.rotation = rotation; //Set the rotation
    }
    public virtual void initRotate() {
        float initAngle = gunRotator.transform.rotation.z;
        aimDirection.x = Mathf.Cos(initAngle * Mathf.Deg2Rad);
        aimDirection.y = Mathf.Sin(initAngle * Mathf.Deg2Rad);
    }
}
