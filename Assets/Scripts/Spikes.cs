using UnityEngine;

public class Spikes : MonoBehaviour
{
	public SpriteRenderer graphics;
	public bool isHidden = true;
	public int damageOnCollision;

	private void Awake()
	{
		graphics.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (!graphics.enabled) graphics.enabled = true;
			PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
			playerHealth.TakeDamage(damageOnCollision);
		}
	}
}
