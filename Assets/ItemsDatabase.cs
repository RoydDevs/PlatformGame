using UnityEngine;

public class ItemsDatabase : MonoBehaviour
{
    public Item[] allItems;

    public static ItemsDatabase instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than 1 instance of ItemsDatabase in the scene");
            return;
        }

        instance = this;
    }
}
