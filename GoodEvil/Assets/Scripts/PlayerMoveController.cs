using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Entity entity;
    private Vector2 movement;
    public Animator animator;

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
        animator.SetFloat("VelocityX", movement.x);
        animator.SetFloat("VelocityY", movement.y);

        if (movement == Vector2.zero)  
        {
            animator.SetBool("IsWalking", false);
        }
        else
        {
            animator.SetBool("IsWalking", true);
        }
       /* if (movement.x > 0 ) 
        {
            animator.SetFloat("Pos", 0);
        }
        else if(movement.x < 0)
        {
            animator.SetFloat("Pos", 2);
        }

        else if (movement.y < 0)
        {
            animator.SetFloat("Pos", 1);
        }*/ 
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + entity.stats.speed * Time.fixedDeltaTime * movement);
    }

}
