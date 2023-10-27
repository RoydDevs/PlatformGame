using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool gameIsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject settingsMenuUI;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(gameIsPaused)
			{
				ResumeGame();
			}
			else
			{
				Paused();
			}
		}
	}

	void Paused()
	{
		//Set player movement to off (fix jump during pause menu is opened)
		PlayerMovement.instance.enabled = false;
		//Open pause menu
		pauseMenuUI.SetActive(true);
		//Stop time (time is set between 0 and 1)
		Time.timeScale = 0;
		//Change game status
		gameIsPaused = true;
	}

	public void ResumeGame()
	{
		PlayerMovement.instance.enabled = true;
		//Close pause menu
		pauseMenuUI.SetActive(false);
		//Reset time
		Time.timeScale = 1;
		//Change game status
		gameIsPaused = false;
	}

	public void MainMenu()
	{
		DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
		ResumeGame();
		SceneManager.LoadScene("MainMenu");
	}

	public void Settings()
	{
		settingsMenuUI.SetActive(true);
	}

	public void CloseSettings()
	{
		settingsMenuUI.SetActive(false);
	}
}
