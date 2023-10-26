using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than 1 instance of GameOverManager in the scene");
        }

        instance = this;
    }

    public void OnPlayerDeath()
	{
		gameOverUI.SetActive(true);
	}
}
