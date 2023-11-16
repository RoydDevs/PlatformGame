using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than 1 instance of GameOverManager in the scene");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
	{
		gameOverUI.SetActive(true);
	}

    //Retry the level
    public void RetryButton()
	{
        //Remove coins get in the level from coins counter
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpCount);
        //Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
	}

    public void MainMenuButton()
	{
        SceneManager.LoadScene("MainMenu");
    }

    //Close the game
    public void QuitButton()
	{
        Application.Quit();
	}
}
