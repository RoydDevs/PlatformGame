using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public int coinsCount;
	public Text coinsCountText;

	//Singleton --> variable static to be able to access inventory everywhere in the game (and only 1 inventory is authorized)
	public static Inventory instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("There is more than 1 instance of Inventory in the scene");
		}

		instance = this;
	}

	public void AddCoins(int count)
	{
		coinsCount += count;
		UpdateTextUI();
	}

	public void RemoveCoins(int count)
	{
		coinsCount -= count;
		UpdateTextUI();
	}

	public void UpdateTextUI()
	{
		coinsCountText.text = coinsCount.ToString();
	}
}
