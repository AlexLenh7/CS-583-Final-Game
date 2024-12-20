using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Health healthBar;
    public Mana manaBar;     
    public int maxHP = 100;
    public int currHP;
    public int maxMana = 100;
    public int currentMana;
    public bool isDead = false;
    public Animator animator;
    public int manaRegen = 20; 
    float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
        currentMana = maxMana;

        healthBar.InitializeBars(maxHP);
        healthBar.UpdateHealthBar(currHP);

        manaBar.InitializeBars(maxMana);
        manaBar.UpdateManaBar(currentMana);
    }

    // check how much time has passed to regen mana
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > .5f) //change time if needed
        {
            PassiveMana(manaRegen);
            timePassed = 0f;
        }
    }

    public void TakeDamage(int damage)
    {
        // if dead skip damage
        if (isDead)
        {
            return;
        }

        // subtract health and update health bar
        currHP -= damage;
        if (currHP < 0) 
        {
            currHP = 0;
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currHP);
        }

        //Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);

        // call die function
        if (currHP == 0 && !isDead)
        {
            Die();
        }
    }

    // passively regenerate mana if mana isn't full
    public void PassiveMana(int manaAmount)
    {
        if (currentMana >= maxMana)
        {
            return;
        }

        currentMana += manaAmount;
        manaBar.UpdateManaBar(currentMana);

    }

    // function to use mana 
    public bool UseMana(int amount)
    {
        // Check if there is enough mana
        if (currentMana < amount) 
        {
            return false;
        }

        // Deduct mana
        currentMana -= amount;

        // Update mana bar
        if (manaBar != null)
        {
            manaBar.UpdateManaBar(currentMana);
        }

        return true; // Deduction succeeded
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




