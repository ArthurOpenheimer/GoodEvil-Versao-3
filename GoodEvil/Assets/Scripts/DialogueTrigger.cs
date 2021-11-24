using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public Dialogue dialogue;
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
		if (Input.GetKeyDown("e") && isTrigger==true)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}
    }
	//Trigger for the Dialogue
}