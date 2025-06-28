using UnityEngine;

public class Chest : MonoBehaviour
{
    public float health = 1f; // Move this outside of Start()

    // Start is called before the first frame update
    void Start()
    {
        // Optional initialization
    }

    // Call this method to deal damage to the chest
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add death logic here (e.g., play animation, drop loot, etc.)
        Destroy(gameObject); // Destroys the chest
    }
}