using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string levelToLoad;

	public GameObject settingsMenuUI;

	public void StartGame()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void Settings()
	{
		settingsMenuUI.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void CloseSettings()
	{
		settingsMenuUI.SetActive(false);
	}
}
