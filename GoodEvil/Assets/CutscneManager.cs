using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscneManager : MonoBehaviour
{
    private int count = 0;
    public GameObject[] cg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Count()
    {
        count++;
    }
   public void NextCs()
    {
        if (count <= cg.Length)
        {
            cg[count - 1].SetActive(false);
            cg[count].SetActive(true);
        }

    }
}