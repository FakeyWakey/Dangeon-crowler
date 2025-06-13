using UnityEngine;

public class ItemsForInv
{
    public enum ItemType
    {
        None,
        Sword,
        HealthPotion,
        Coin,
    }

    public ItemType itemType;
    public int amount;

}
