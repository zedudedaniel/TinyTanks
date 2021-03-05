using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootAI : MonoBehaviour
{
    [HideInInspector]
    public Vector2 aimDirection = new Vector2(1, 0);
    public virtual bool decideShoot()
    {
        return false;
    }
}
