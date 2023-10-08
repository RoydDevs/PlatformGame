using UnityEngine;
using UnityEngine.SceneManagement;

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

    //Set player as child of the platform : make it follow the platform movement
	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
	}

    //Remove player as child of the platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //When remove player from parent --> not send back to DontDestroyOnload
            collision.transform.SetParent(null);
            //Add again player in DontDestroyOnLoad scene
            DontDestroyOnLoad(collision.gameObject);
        }
	}
}
