using UnityEngine;
using System.Collections.Generic;
using System.Collections;   

public class ItemPickup : MonoBehaviour
{
 public Item item;


    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        Pickup();
    }
}

