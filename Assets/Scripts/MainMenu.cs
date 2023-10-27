using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public string levelToLoad;

	public GameObject settingWindow;

	public void StartGame()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void Settings()
	{
		settingWindow.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void CloseSettings()
	{
		settingWindow.SetActive(false);
	}
}
