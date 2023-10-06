using UnityEngine;

public class FlagMovement : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			gameObject.GetComponent<Animator>().SetTrigger("IsActivated");
		}
	}
}
