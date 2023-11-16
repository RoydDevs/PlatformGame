using UnityEngine;
using System.Collections;

public class WeakSpot : MonoBehaviour
{
    public GameObject EnemyToDestroy;

    public SpriteRenderer graphics;
    public float destructionFlashDelay;
    public int enemiDestructionDelayAfterHit;
    public bool enemyKilled;
    public Animator animator;

    public EnemyMovement enemyMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("IsDead");
            enemyKilled = true;
            enemyMovement.RemoveColliderOnDeath();
            enemyMovement.StopEnemy();
            StartCoroutine(DeathFlash());
            StartCoroutine(HandleEnemyDestruction());
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

    public IEnumerator HandleEnemyDestruction()
    {
        yield return new WaitForSeconds(enemiDestructionDelayAfterHit);
        GameObject.Destroy(EnemyToDestroy);
    }
}
