using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float platformSpeed;
    public Transform[] waypoints;

    private Transform target;
    private int destPoint;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * platformSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
		{
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
		}
    }
}
