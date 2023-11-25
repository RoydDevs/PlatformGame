using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
	public bool isInRange = false;
	public AudioClip audioClip;

	public Item item;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && isInRange)
		{
			TakeItem();
		}
	}

	void TakeItem()
	{
		Inventory.instance.content.Add(item);
		Inventory.instance.UpdateInventoryUI();
		AudioManager.instance.PlayClipAt(audioClip, transform.position);
		InteractUI.instance.HideInteractUI();
		Destroy(gameObject);
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
		}
	}
}
