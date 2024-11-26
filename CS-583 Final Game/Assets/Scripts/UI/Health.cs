using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;
    private int maxHealth;

    // Initialize health bar
    public void InitializeBars(int maxHealth)
    {
        this.maxHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    // Update the health bar
    public void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}





