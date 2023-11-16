using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			//Move the player spawn to the checkpoint
			CurrentSceneManager.instance.respawnPoint = gameObject.transform.position;
			//Disabled last checkpoint taken to don't be able to take it again
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
