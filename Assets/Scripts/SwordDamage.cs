using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private float damage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
           
        }
    }
}











