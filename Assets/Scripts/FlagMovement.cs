using UnityEngine;

public class FlagMovement : MonoBehaviour
{
	public Animator animator;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			animator.SetTrigger("IsActivated");
		}
	}
}
