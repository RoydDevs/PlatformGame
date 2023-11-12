using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
	public int coinsPickedUpCount;
	public Vector3 respawnPoint;

	public static CurrentSceneManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("There is more than 1 instance of CurrentSceneManager in the scene");
			return;
		}

		instance = this;

		respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
	}
}
