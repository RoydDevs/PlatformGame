using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text itemName;
    public Image itemImage;
    public Text itemPrice;

    public Item item;

    public void BuyItem()
	{
        Inventory inventory = Inventory.instance;

        //Check if player got enough coins
        if(inventory.coinsCount >= item.price)
		{
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateTextUI();
		}
	}
}
