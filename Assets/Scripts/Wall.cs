using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool isDestroyedByBullets;
    public bool isDestroyedByMines;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<Projectile>() != null && isDestroyedByBullets) //If the thing is a projectile, and this can be killed by bullets...
        {
            Destroy(collision.collider.gameObject); //Destroy the bullet.
            Destroy(gameObject); //Destroy this. (Duh)
        }
    }
}