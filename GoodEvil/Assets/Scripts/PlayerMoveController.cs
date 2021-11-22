using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Entity entity;
    private Vector2 movement;

    void Start()
    {
        entity = GetComponent<Entity>();
        rb = GetComponent<Rigidbody2D>();
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
    }

}
