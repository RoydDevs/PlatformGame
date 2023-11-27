using UnityEngine;
using System.Linq;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than 1 instance of LoadAndSaveData in the scene");
            return;
        }

        instance = this;
    }

    void Start()
    {
        LoadData();
    }

    //Save data when player reach an end leve
    public void SaveData()
	{
        //Regedit : Computer\HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\DefaultCompany\Platform Game
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        /*PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);*/

        if(CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }

        //Items save : create a string with each item ids
        string itemsInInventory = string.Join(",", Inventory.instance.content.Select(x => x.id));
        PlayerPrefs.SetString("inventoryItems", itemsInInventory);
	}

    public void LoadData()
	{
        //Load coins
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUI();

        //Load player health
        /*int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/

        //Load player items
        string[] itemsSaved = PlayerPrefs.GetString("inventoryItems").Split(',', System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < itemsSaved.Length; i++)
        {
            int id = int.Parse(itemsSaved[i]);
            Item currentItem = ItemsDatabase.instance.allItems.Single(x => x.id == id);
            Inventory.instance.content.Add(currentItem);
        }
        Inventory.instance.UpdateInventoryUI();
    }
}
