using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    [SerializeField] private float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(damage);
    }


}