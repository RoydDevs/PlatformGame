using UnityEngine;

public class EnemiMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] waypoints;

    public int damageOnCollision;

    private Transform target;
    private int destPoint;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(damageOnCollision);
    }

    public void RemoveColliderOnDeath()
    {
        var collider = transform.GetComponent<BoxCollider2D>();
        Destroy(collider);
    }

    public void StopEnemi()
    {
        moveSpeed = 0;
    }
} 
