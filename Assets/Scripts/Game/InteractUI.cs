using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
	private GameObject interactUI;

	public static InteractUI instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("There is more than 1 instance of InteractUI in the scene");
		}

		instance = this;

		interactUI = GameObject.FindGameObjectWithTag("InteractUI");
		HideInteractUI();
	}

	public void HideInteractUI()
	{
		interactUI.SetActive(false);
	}

	public void ShowInteractUI()
	{
		interactUI.SetActive(true);
	}
}
