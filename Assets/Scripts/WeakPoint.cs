using UnityEngine;
using System.Collections;

public class WeakSpot : MonoBehaviour
{
    public GameObject EnemiToDestroy;

    public SpriteRenderer graphics;
    public float destructionFlashDelay;
    public int enemiDestructionDelayAfterHit;
    public bool enemyKilled;
    public Animator animator;

    public EnemiMovement enemiMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetFloat("Speed", 0);
            enemyKilled = true;
            enemiMovement.RemoveColliderOnDeath();
            enemiMovement.StopEnemi();
            StartCoroutine(DeathFlash());
            StartCoroutine(HandleEnemiDestruction());
        }
    }

    public IEnumerator DeathFlash()
    {
        while(enemyKilled)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(destructionFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(destructionFlashDelay);
        }
    }

    public IEnumerator HandleEnemiDestruction()
    {
        yield return new WaitForSeconds(enemiDestructionDelayAfterHit);
        GameObject.Destroy(EnemiToDestroy);
    }
}
