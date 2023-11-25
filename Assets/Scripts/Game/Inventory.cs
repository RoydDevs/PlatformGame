using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public int coinsCount;
	public Text coinsCountText;

	public List<Item> content = new List<Item>();
	public int contentCurrentIndex = 0;
	public Image itemImageUI;
	public Text itemNameUI;
	public Sprite emptyItemImage;

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

	public void Start()
	{
		UpdateInventoryUI();
	}

	public void ConsumeItem()
	{
		if(content.Count == 0)
		{
			return;
		}

		Item currentItem = content[contentCurrentIndex];
		PlayerHealth.instance.ReceiveHealing(currentItem.hpGiven);
		PlayerMovement.instance.moveSpeed += currentItem.speedGiven;
		content.Remove(currentItem);
		GetNextItem();
		UpdateInventoryUI();
	}

	public void GetNextItem()
	{
		if (content.Count == 0)
		{
			return;
		}

		contentCurrentIndex++;
		if(contentCurrentIndex > content.Count - 1)
		{
			contentCurrentIndex = 0;
		}
		UpdateInventoryUI();
	}

	public void GetPreviousItem()
	{
		if (content.Count == 0)
		{
			return;
		}

		contentCurrentIndex--;
		if (contentCurrentIndex < 0)
		{
			contentCurrentIndex = content.Count - 1;
		}
		UpdateInventoryUI();
	}

	public void UpdateInventoryUI()
	{
		if(content.Count > 0)
		{
			itemImageUI.sprite = content[contentCurrentIndex].image;
			itemNameUI.text = content[contentCurrentIndex].itemName;
		}
		else
		{
			itemImageUI.sprite = emptyItemImage;
			itemNameUI.text = "";
		}
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
