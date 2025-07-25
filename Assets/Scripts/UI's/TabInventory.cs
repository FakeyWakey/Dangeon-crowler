using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryPanel; // przypisujesz tu panel z Canvy
    public InventoryManager inventoryManager;   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
            inventoryManager.ListItems();
        }
    }

}