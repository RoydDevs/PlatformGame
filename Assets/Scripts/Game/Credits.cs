using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void LoadMainMenu()
	{
        SceneManager.LoadScene("MainMenu");
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
            LoadMainMenu();
		}
    }
}
