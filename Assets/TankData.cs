using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExampleTankData", menuName = "TankData")]
public class TankData : ScriptableObject
{

    public Color Color;
    [Header("Movement")]
    public MoveCode MoveCode;
    public float MoveSpeed;

    [Header("Shooting")]
    public ShootCode ShootCode;
    //public ProjectileType ProjectileType;
    public float FireRate;
    public int NumberOfProjectileBounces;
    public int BulletLimit;
}
