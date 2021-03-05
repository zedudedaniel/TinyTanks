using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //DO NOT GIVE THIS TO TANKS WHO DON'T MOVE.
    //THERE IS NO "No movement" AI but it requires an AI to function properly.
    public MovementAI movementType;
    public Rigidbody2D rb;
    public Vector2 movement;
    public float moveSpeed;

    public void Update()
    {
        movement = movementType.decideMovement();
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
