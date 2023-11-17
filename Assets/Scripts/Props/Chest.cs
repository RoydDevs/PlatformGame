using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
	public bool isInRange = false;

	public Animator animator;
	public int coinsToAdd;
	public AudioClip audioClip;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && isInRange)
		{
			OpenChest();
		}
	}

	void OpenChest()
	{
		animator.SetTrigger("OpenChest");
		Inventory.instance.AddCoins(coinsToAdd);
		AudioManager.instance.PlayClipAt(audioClip, transform.position);
		//Deactivate the collider to avoid taking 
		GetComponent<BoxCollider2D>().enabled = false;
		InteractUI.instance.HideInteractUI();
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
		if(collision.CompareTag("Player"))
		{
			isInRange = false;
			InteractUI.instance.HideInteractUI();
		}
	}
}
