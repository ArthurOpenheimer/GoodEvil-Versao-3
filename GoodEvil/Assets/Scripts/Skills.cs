using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform trans;
    public Animator anim;
    public Vector2 direction;

    public List<string> ignoreObjects = new List<string>();
    public int speed = 5;
    public int damage = 10;
    public int manaCost;

    private bool _ready = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        trans = gameObject.GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!_ready) return;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    public void Init(Vector2 dir, List<string> ignoreObjectsList)
    {
        ignoreObjects = ignoreObjectsList;
        direction = dir;
        _ready = true;
        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Stats otherHealth = other.gameObject.GetComponent<Stats>();
        string otherTag = other.gameObject.tag;

        if (!otherHealth) return;

        foreach (string tag in ignoreObjects)
        {
            if (otherTag == tag) return;
        }

        otherHealth.Damage(damage);

        Destroy(gameObject);
    }
}
