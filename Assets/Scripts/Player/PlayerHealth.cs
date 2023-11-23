using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvicible = false;
    public float invicibilityTimeAfterHit = 2.5f;
    public float invicibiltyFlashDelay = 0.2f;

    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public AudioClip hitAudioClip;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than 1 instance of PlayerHealth in the scene");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //To test
        if (Input.GetKeyDown(KeyCode.H))
		{
            TakeDamage(60);
		}
    }

    public void ReceiveHealing(int healthCount)
	{
        if ((currentHealth + healthCount) > 100)
		{
            currentHealth = maxHealth;
		}
        else
		{
            currentHealth += healthCount;
		}

        healthBar.SetHealth(currentHealth);
	}

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            AudioManager.instance.PlayClipAt(hitAudioClip, transform.position);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //check health
            if (currentHealth <= 0)
			{
                Die();
                return;
			}

            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
	{
        PlayerMovement.instance.DisablePlayerInteractions();
        //Play death animation
        PlayerMovement.instance.animator.SetTrigger("Die");
        //Open game over menu
        GameOverManager.instance.OnPlayerDeath();
	}

    public void Respawn()
	{
        //Stop player interactions
        PlayerMovement.instance.EnablePlayerInteractions();
        //Play animation idle
        PlayerMovement.instance.animator.SetTrigger("Respawn");
        //Reset player health
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibiltyFlashDelay);
            graphics.color = new Color(1f, .45f, .45f, 1f);
            yield return new WaitForSeconds(invicibiltyFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
        graphics.color = new Color(1f, 1f, 1f, 1f);
    }
}