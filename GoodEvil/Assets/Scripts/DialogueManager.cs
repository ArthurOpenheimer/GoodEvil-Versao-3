using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	public Image Portrait;

	public Sprite newSprite;
	public Sprite[] Portraits;

	private Queue<string> sentences;
	private Queue<string> names;
	public int currentLine;
	//Use this for initialization
	void Start()
	{

		sentences = new Queue<string>();
		names = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		sentences.Clear();
		//Opening and cleaning the DialogueBox
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		//separating all the sentences in coordinates of a String
		foreach (string name in dialogue.names)
        {
			names.Enqueue(name);
        }
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
        if (currentLine == 4) { currentLine = 0; }
		Portrait.sprite = newSprite;
		newSprite = Portraits[currentLine];
		currentLine++;
		string sentence = sentences.Dequeue();
		string name = names.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence, name));

	}

	IEnumerator TypeSentence(string sentence, string name)
	{
		dialogueText.text = "";
		nameText.text = name;
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}

	}
	//writing the sentence 

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}
	//Closing the DialogueBox
}
