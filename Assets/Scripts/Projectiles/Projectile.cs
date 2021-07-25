using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    public int bounces;
    public float speed;
    public Sprite sprite;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public Shoot creator;
    public GameObject target;
    
    protected void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        //tellIncoming();
    }
    private void OnDestroy()
    {
        creator.bullets.Remove(this);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.collider.gameObject; //Quick way to reference the other object hit
        if (otherObject.GetComponent<Projectile>()!=null) //If this hit another projectile...
        {
            Destroy(gameObject); //Destroy this object. The other one will run this too, so no need to say to destroy the other. (Unless it doesn't destroy itself, in case we don't write this here either.)
            return;
        } else if (otherObject.GetComponent<Wall>()!=null) //If this is a wall of some kind...
        {
            Bounce(collision); //If this hit a wall, bounce!
        } else if (otherObject.GetComponent<Tank>() != null) //If this is a tank...
        {
            Destroy(gameObject);
            Destroy(otherObject);
        }
    }
    protected void Bounce(Collision2D collision)
    {
        if (bounces <= 0) //If this is out of bounces...
        {
            Destroy(gameObject);
            return;
        }
        //Vector2 inDirection = rb.velocity;
        Vector2 inNormal = collision.contacts[0].normal; //Normal needed to count bounce direction
        Vector2 newVelocity = Vector2.Reflect(direction, inNormal); //Calculate next direction
        direction = newVelocity; //Set next direction

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Calculate the angle, needed for rotation
        Quaternion rotation = Quaternion.Euler(0, 0, angle - 90); //Calculate the rotation
        transform.rotation = rotation; //Set the rotation
        bounces -= 1;
        //tellIncoming();
        //Debug.Log(rb.velocity);
    }
} 