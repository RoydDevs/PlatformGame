using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
	public BoxCollider2D topCollider;

	private bool isInRange;
	private PlayerMovement playerMovement;

	private Text interactUI;

	private void Awake()
	{
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
		interactUI.enabled = false;
	}

	private void Update()
	{
		if (isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
		{
			playerMovement.isClimbing = false;
			topCollider.isTrigger = false;
			//stop the update with a return to don't read the following lines
			return;
		}

		if (isInRange && Input.GetKeyDown(KeyCode.E))
		{
			playerMovement.isClimbing = true;
			topCollider.isTrigger = true;
		}
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
		if (collision.CompareTag("Player"))
		{
			isInRange = false;
			playerMovement.isClimbing = false;
			topCollider.isTrigger = false;
			interactUI.enabled = false;
		}
	}
}
