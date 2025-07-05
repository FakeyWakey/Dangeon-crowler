using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;

    public float damage = 2f;   // to fajnie by³oby gdyby by³¹ zmienna


    private void Start()
    {
        currentHealth = maxHealth;
    }




    public void DamageHealth(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = Mathf.Max(currentHealth - damage, 0f);   //damage enemy take
            Debug.Log("Took damage! Current Health: " + currentHealth);  //infor for unity that enemy takes damage

            if (currentHealth == 0f)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}