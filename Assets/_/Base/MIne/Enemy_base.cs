using System;
using System.Linq;
using UnityEngine;

public class Enemy_base : MonoBehaviour
{
    // Public variables
    public float moveSpeed = 2f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float health = 100f;
    public Transform player;
    public float attackCooldown = 3f;
    public float detectionRadius = 10f;
    public Transform[] waypoints;

    private int currentWaypointIndex = 0;
    private float nextAttackTime = 0f;

    private void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Player in range — chase
            MoveTowards(player.position);

            if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time >= nextAttackTime)
            {
                Attack();
            }
        }
        else
        {
            // Patrol between waypoints
            Patrol();
        }
    }

    private void MoveTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void Patrol()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        MoveTowards(targetWaypoint.position);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    private void Attack()
    {
        if (player != null)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            nextAttackTime = Time.time + attackCooldown;
        }
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