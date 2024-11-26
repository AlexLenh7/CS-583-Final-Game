using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Health healthBar;
    public Mana manaBar;     
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMana = 100;
    public int currentMana;
    public bool isDead = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;

        healthBar.InitializeBars(maxHealth);
        healthBar.UpdateHealthBar(currentHealth);

        manaBar.InitializeBars(maxMana);
        manaBar.UpdateManaBar(currentMana);
    }

    void TakeDamage(int damage)
    {
        // if dead skip damage
        if (isDead)
        {
            return;
        }

        // subtract health and update health bar
        currentHealth -= damage;
        if (currentHealth < 0) 
        {
            currentHealth = 0;
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth);
        }

        //Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);

        // call die function
        if (currentHealth == 0 && !isDead)
        {
            Die();
        }
    }

    // function to use mana 
    public void UseMana(int amount)
    {
        // skip mana usage if there is none
        if (currentMana <= 0) 
        {
            return;
        }

        // subtract mana and update mana bar
        currentMana -= amount;
        if (currentMana < 0) 
        {
            currentMana = 0;
        }

        if (manaBar != null)
        {
            manaBar.UpdateManaBar(currentMana);
        }

        //Debug.Log("Player used " + amount + " mana. Current mana: " + currentMana);
    }

    void Die()
    {
        // set isdead to true
        isDead = true;
        //Debug.Log("Player has died.");

        // Trigger any additional death animation
        // if (animator != null)
        // {
        //     animator.SetBool("isDead", true);
        // }
    }

    // Test to see if health/mana bars work
    // delete if needed
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         TakeDamage(10); 
    //         UseMana(15);    
    //     }
    // }
}




