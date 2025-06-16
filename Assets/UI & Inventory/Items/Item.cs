using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Create new Item")]
public class Item : ScriptableObject

{
    public string itemName;
    public string description;
    public Sprite icon;
 
    public int value; 
    public Itemtype itemtype;

    public void Use()
    {
        Debug.Log("Using item: " + itemName);
        
    }
    public enum Itemtype
    {
       Potion,
       Weapon,
       Gold,
        
    }
}