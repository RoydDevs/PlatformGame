using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

	private bool isInRange;

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
		{
			TriggerDialogue();
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isInRange = true;
			InteractUI.instance.ShowInteractUI();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isInRange = false;
			InteractUI.instance.HideInteractUI();
			//Remove dialogue if we move
			DialogueManager.instance.EndDialogue();
		}
	}

	void TriggerDialogue()
	{
		DialogueManager.instance.StartDialogue(dialogue);
	}
}
