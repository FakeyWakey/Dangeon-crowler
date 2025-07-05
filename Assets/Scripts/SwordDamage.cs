using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private float damage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        // Make sure we only damage objects tagged as "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Try to get the Enemy_base script from the hit object
            Enemy_base enemy = other.GetComponent<Enemy_base>();

            if (enemy != null)
            {
                // Apply damage to the enemy
                enemy.TakeDamage(damage);
                Debug.Log($"[Sword] Hit enemy: {other.name}, damage dealt: {damage}");
            }
            else
            {
                Debug.LogWarning($"[Sword] Object with 'Enemy' tag has no Enemy_base script: {other.name}");
            }
        }
    }
}









