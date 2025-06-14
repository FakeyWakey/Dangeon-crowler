using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Create new Item")]
public class Item : ScriptableObject

{
    public string itemName;
    public string description;
    public Sprite icon;
    public int maxStackSize = 1;
    // You can add more properties as needed, such as item type, rarity, etc.
    public string value; // Value of the item, can be a string for flexibility
    // Example method to use the item
    public void Use()
    {
        Debug.Log("Using item: " + itemName);
        // Implement item usage logic here
    }
}