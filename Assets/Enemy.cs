using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Public variables (accessible in the Unity Inspector)
    public float moveSpeed = 2f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float health = 100f;
    public Transform player; // Reference to Alan
    public float attackCooldown = 3f;
    // set radious if enemy sees player  
    private class PlayerHealth
    {
        internal void TakeDamage(float attackDamage)
        {
            throw new NotImplementedException();
        }
    }

    // Private variables
    private float nextAttackTime = 1f; // Time when the enemy can attack again

    // Function called every frame
    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            MoveTowardsPlayer();
            // Check if the enemy is within attack range and if the attack cooldown is over
            if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time >= nextAttackTime)
            {
                Attack();
            }
        }
    }

    // Move the enemy towards the player
    private void MoveTowardsPlayer()
    {
        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the enemy using the calculated direction and move speed
        transform.position += direction * moveSpeed * Time.deltaTime;

    }

    // Attack the player
    private void Attack()
    {
        // Apply damage to the player (requires health)
        if (player != null)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage); // Kod Alana
        }

        // Set the next attack time to allow for a cooldown
        nextAttackTime = Time.time + attackCooldown;

    }


    // Called when the enemy is hit
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
        // You can add death logic here
        Destroy(gameObject);
    }
}
