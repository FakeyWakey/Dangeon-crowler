using UnityEngine;
using UnityEngine.AI;

public class Enemy_base : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackDamage = 2f;
    public float health = 10f;
    public float attackCooldown = 3f;
    public float detectionRange = 2f; // How far the enemy "sees" the player
    public Transform player;

    private float nextAttackTime = 0f;
    private NavMeshAgent agent;
    private NavigacionScript patrolScript;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolScript = GetComponent<NavigacionScript>();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                // Stop patrolling and chase player
                if (patrolScript != null)
                    patrolScript.enabled = false;

                agent.SetDestination(player.position);

                // Attack if close enough
                if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
                {
                    Attack();
                }
            }
            else
            {
                // Player is far away, go back to patrolling
                if (patrolScript != null && !patrolScript.enabled)
                {
                    patrolScript.enabled = true;
                }
            }
        }
    }

    private void Attack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage((int)attackDamage);
        }

        nextAttackTime = Time.time + attackCooldown;
    }

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
        Destroy(gameObject);
    }
}