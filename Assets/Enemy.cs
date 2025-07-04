using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float enemyHealth = 10f;
    public float attackCooldown = 3f;
    public Transform player;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();

            if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void Attack()
    {
        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            ph.TakeDamage((int)attackDamage);
        }
        else
        {
            Debug.LogWarning("Player nie ma komponentu PlayerHealth!");
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
       
        Destroy(gameObject);
    }
}