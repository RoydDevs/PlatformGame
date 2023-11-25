using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
	public int hearthHealingCount;

	public AudioClip coinAudioClip;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (transform.CompareTag("Coin"))
			{
				AudioManager.instance.PlayClipAt(coinAudioClip, transform.position);
				Inventory.instance.AddCoins(1);
				CurrentSceneManager.instance.coinsPickedUpCount++;
			}
			else if (transform.CompareTag("Hearth"))
			{
				PlayerHealth.instance.ReceiveHealing(hearthHealingCount);
			}
			Destroy(gameObject);
		}
	}
}
