using UnityEngine;
using System.Collections.Generic;
using TMPro;           // Namespace dla TextMeshPro
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        // Usuñ poprzednie elementy z listy UI
        foreach (Transform child in ItemContent)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            // Pobierz InventoryItemController i przypisz item
            InventoryItemController controller = obj.GetComponent<InventoryItemController>();
            if (controller != null)
            {
                controller.AddItem(item);
            }
            else
            {
                Debug.LogError("Prefab InventoryItem nie ma komponentu InventoryItemController!");
            }

            Transform nameTransform = obj.transform.Find("ItemName");
            Transform iconTransform = obj.transform.Find("ItemIcon");

            if (nameTransform == null || iconTransform == null)
            {
                Debug.LogError("Prefab InventoryItem nie zawiera 'ItemName' lub 'ItemIcon'.");
                continue;
            }

            TMP_Text itemName = nameTransform.GetComponent<TMP_Text>();
            Image itemIcon = iconTransform.GetComponent<Image>();

            if (itemName == null || itemIcon == null)
            {
                Debug.LogError("Brakuje komponentów TMP_Text lub Image w prefabie InventoryItem.");
                continue;
            }

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }
}
