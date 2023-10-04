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
				PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
				playerHealth.ReceiveHealing(hearthHealingCount);
			}
			Destroy(gameObject);
		}
	}
}
