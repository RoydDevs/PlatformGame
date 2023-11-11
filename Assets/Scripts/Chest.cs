using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
	public bool isInRange = false;
	private Text interactUI;

	public Animator animator;
	public int coinsToAdd;
	public AudioClip audioClip;

	private void Awake()
	{
		interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
		interactUI.enabled = false;
	}

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
		interactUI.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isInRange = true;
			interactUI.enabled = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			isInRange = false;
			interactUI.enabled = false;
		}
	}
}
