using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices: MonoBehaviour
{

	public Dialogue dialogue;

	public Animator animator;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		animator.SetBool("IsOpen", true);
		
	}
	//Trigger for the Dialogue
}