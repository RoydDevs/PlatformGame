using UnityEngine;

public class Ladder : MonoBehaviour
{
	public new BoxCollider2D collider;

	private bool isInRange;
	private PlayerMovement playerMovement;

	private void Awake()
	{
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}

	private void Update()
	{
		if (playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
		{
			playerMovement.isClimbing = false;
			collider.isTrigger = false;
			//stop the update with a return to don't read the following lines
			return;
		}

		if (isInRange && Input.GetKeyDown(KeyCode.E))
		{
			playerMovement.isClimbing = true;
			collider.isTrigger = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			isInRange = false;
			playerMovement.isClimbing = false;
			collider.isTrigger = false;
		}
	}
}
