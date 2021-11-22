using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall01 : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool ready;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready) return;
    }

    public void Inicialize(Vector2 dir)
    {
        rb.velocity = dir * speed;
        ready = true;
    } 
}
