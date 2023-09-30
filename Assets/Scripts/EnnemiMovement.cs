using UnityEngine;

public class EnnemiMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint;
    public Animator blopAnimator;

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
}
