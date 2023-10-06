using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	private Animator animatorFlag;

	private Transform playerSpawn;

	private void Awake()
	{
		playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
		animatorFlag = GameObject.FindGameObjectWithTag("Flag").GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			//Move the player spawn to the checkpoint
			playerSpawn.position = gameObject.transform.position;
			//Disabled last checkpoint taken to don't be able to take it again
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
