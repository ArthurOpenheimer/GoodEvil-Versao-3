using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuturialHit : MonoBehaviour
{
    public GameObject[] dialogues;
    private int Count;
    // Start is called before the first frame update       #SobrevivaOP
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BigFire")
        {
            if (Count == 1) 
            {
                dialogues[0].SetActive(false);
                dialogues[1].SetActive(false);
                dialogues[2].SetActive(true);
                dialogues[3].SetActive(false);
                Count++;
            }
        }
        if(other.gameObject.tag == "SmallFire")
        {
            if (Count == 0)
            {
                dialogues[0].SetActive(false);
                dialogues[1].SetActive(true);
                dialogues[2].SetActive(false);
                dialogues[3].SetActive(false);
                Count++;
            }
        }
    }
}
