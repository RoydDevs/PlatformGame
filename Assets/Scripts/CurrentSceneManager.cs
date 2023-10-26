using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;
	public int coinsPickedUpCount;

	public static CurrentSceneManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("There is more than 1 instance of CurrentSceneManager in the scene");
			return;
		}

		instance = this;
	}
}
