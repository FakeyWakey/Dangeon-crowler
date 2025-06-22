using UnityEngine;

public class GoldDrop : MonoBehaviour
{
    public GameObject itemPrefab; // Assign your item prefab in the Inspector
    public int maxDropCount = 5;

    public void DropItems()
    {
        // Drop 3 XP
        for (int i = 0; i < 3; i++)
        {
            Vector3 xpPosition = transform.position + Random.insideUnitSphere * 1.0f;
            xpPosition.y = transform.position.y;
            Instantiate(xpPrefab, xpPosition, Quaternion.identity);
        }
        // Gold 0-5
        int dropCount = Random.Range(0, maxDropCount + 1); // inclusive 0, exclusive (5+1)
        for (int i = 0; i < dropCount; i++)
        {
            Vector3 dropPosition = transform.position + Random.insideUnitSphere * 1.5f;
            dropPosition.y = transform.position.y; // Keep it on the ground level
            Instantiate(itemPrefab, dropPosition, Quaternion.identity);
        }

        Debug.Log("Dropped " + dropCount + " items.");
    }
}