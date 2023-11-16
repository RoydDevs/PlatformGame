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

	public void CloseSettings()
	{
		settingsMenuUI.SetActive(false);
	}

	public void LevelSelect()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void Credits()
	{
		SceneManager.LoadScene("Credits");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
