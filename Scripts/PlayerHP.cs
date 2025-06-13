using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthSlider;
    public Image fillImage; 

    public Color healthyColor = Color.green;
    public Color warningColor = Color.yellow;
    public Color dangerColor = Color.red;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        float healthPercent = (float)currentHealth / maxHealth;
        if (healthSlider != null)
        {
            healthSlider.value = healthPercent;
        }

        if (fillImage != null)
        {
            if (healthPercent > 0.5f)
                fillImage.color = healthyColor;
            else if (healthPercent > 0.25f)
                fillImage.color = warningColor;
            else
                fillImage.color = dangerColor;
        }
    }

    void Die()
    {
        Debug.Log("Gracz zgin¹³!");
    }
}