using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceTrigger : MonoBehaviour
{
    public Animator animator;
    private bool IsOpen;

    private bool isTrigger;
    void OnTriggerEnter2D(Collider2D other)
    {
        isTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isTrigger = false;
    }
    void Update()
    {
        if (Input.GetKeyDown("e") && isTrigger == true)
        {
            animator.SetBool("IsOpen", true);
        }
    }
}
