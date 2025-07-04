using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    private Item item;
    public Button RemoveButton;

    private void Start()
    {
        if (RemoveButton != null)
            RemoveButton.onClick.AddListener(RemoveItem);
        else
            Debug.LogWarning("RemoveButton nie jest przypisany w InventoryItemController.");
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void RemoveItem()
    {
        if (item != null)
        {
            InventoryManager.Instance.Remove(item);
        }
        else
        {
            Debug.LogWarning("Próba usuniêcia nullowego itemu.");
        }

        Destroy(gameObject);
    }

    public void UseItem()
    {
        if (item == null)
        {
            Debug.LogError("Item nie zosta³ przypisany w InventoryItemController!");
            return;
        }

        switch (item.itemtype)
        {
            case Item.Itemtype.Potion:
                if (PlayerHealth.Instance != null)
                {
                    PlayerHealth.Instance.IncreaseHealth(item.value);
                }
                else
                {
                    Debug.LogError("PlayerHealth.Instance jest null!");
                }
                break;

            // Dodaj inne typy itemów, jeœli potrzebujesz

            default:
                Debug.LogWarning($"Brak implementacji dla typu itemu: {item.itemtype}");
                break;
        }

        RemoveItem();
    }
}