using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Entity entity;
    private Vector2 movement;
    public Animator animator;
    public string facing;
    private int animDirection;

    void Start()
    {
        entity = GetComponent<Entity>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Set the maxValue of the Vector
        movement = Vector2.ClampMagnitude(movement, 1f);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + entity.stats.speed * Time.fixedDeltaTime * movement); 
        animator.SetFloat("VelocityX", movement.x);
        animator.SetFloat("VelocityY", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);

        CheckDirection();
        animator.SetFloat("LastDirection", animDirection); 
    }
void CheckDirection()
    {
        if (movement.x > 0)
        {
            facing = "right";
            animDirection = 1;
        }
        else if (movement.y > 0)
        {
            facing = "up";
            animDirection = 0;
        }
        else if (movement.x < 0)
        {
            facing = "left";
            animDirection = 3;
        }
        else if (movement.y < 0)
        {
            facing = "down";
            animDirection = 2;
        } //check where the player is looking 
    }
}
