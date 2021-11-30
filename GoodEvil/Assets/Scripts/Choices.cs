using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices: MonoBehaviour
{

	public Dialogue dialogue;

	public Animator animator;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().resetCL();
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		animator.SetBool("IsOpen", false);
		
	}
	//Trigger for the Dialogue
}