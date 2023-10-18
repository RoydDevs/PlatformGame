using UnityEngine;

public class PickUpObject : MonoBehaviour
{
	public int hearthHealingCount;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (transform.CompareTag("Coin"))
			{
				Inventory.instance.AddCoins(1);
			}
			else if (transform.CompareTag("Hearth"))
			{
				PlayerHealth.instance.ReceiveHealing(hearthHealingCount);
			}
			Destroy(gameObject);
		}
	}
}
