using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	private bool isInRange;

	public string npcName;
	public Item[] itemsToSell;

	void Update()
	{
		if (isInRange && Input.GetKeyDown(KeyCode.E))
		{
			ShopManager.instance.OpenShop(itemsToSell, npcName);
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
			//Remove shop if we move
			ShopManager.instance.CloseShop();
		}
	}
}
