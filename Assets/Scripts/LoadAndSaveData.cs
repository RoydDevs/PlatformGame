using UnityEngine;

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

    public void SaveData()
	{
        //Regedit : Computer\HKEY_CURRENT_USER\SOFTWARE\Unity\UnityEditor\DefaultCompany\Platform Game
        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);
        /*PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);*/
	}

    public void LoadData()
	{
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateTextUI();

        /*int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);*/
	}
}
