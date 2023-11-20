using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than 1 instance of Inventory in the scene");
        }

        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
	{
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
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

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}

    IEnumerator TypeSentence(string sentence)
	{
        dialogueText.text = "";
		foreach (char letter  in sentence.ToCharArray())
		{
            dialogueText.text += letter;
            //Skip 1 frame
            yield return new WaitForSeconds(0.05f);
		}
	}

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
	}
}
