using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown : MonoBehaviour
{
    [System.Serializable]
    public class Skill
    {
        public string skillName;
        public float cooldownDuration;
        public Image cooldownOverlay; 
        public int manaCost;
        [HideInInspector] public float cooldownTimer = 0; // Initialize with zero
        public bool IsOnCooldown => cooldownTimer > 0; // Helper for readability
    }

    public Skill[] skills;
    public PlayerStats playerStats;

    void Update()
    {
        // Change input to something else if needed
        // Check for keyboard input
        if (Input.GetMouseButton(0)) UseSkill(0); // Left Mouse Button for the first skill
        if (Input.GetMouseButtonDown(1)) UseSkill(1); // Right Mouse Button for the second skill
        if (Input.GetKeyDown(KeyCode.Q)) UseSkill(2); // Q for the third skill
        if (Input.GetKeyDown(KeyCode.E)) UseSkill(3); // E for the fourth skill

    }

    public void UseSkill(int skillIndex)
    {
        if (skillIndex < 0 || skillIndex >= skills.Length) return;

        Skill skill = skills[skillIndex];

        if (playerStats.currentMana < skill.manaCost)
        {
            Debug.Log($"Cannot use {skill.skillName}: Not enough mana.");
            return;
        }

        if (skill.IsOnCooldown)
        {
            Debug.Log($"Cannot use {skill.skillName}: Skill is on cooldown.");
            return;
        }

        // Deduct mana and start the cooldown
        playerStats.UseMana(skill.manaCost);
        skill.cooldownTimer = skill.cooldownDuration;
        StartCoroutine(HandleCooldown(skill));

        Debug.Log($"Used skill: {skill.skillName}");
    }


    private IEnumerator HandleCooldown(Skill skill)
    {
        skill.cooldownOverlay.fillAmount = 1f;
        skill.cooldownOverlay.gameObject.SetActive(true);

        float elapsed = 0;
        while (elapsed < skill.cooldownDuration)
        {
            elapsed += Time.deltaTime;
            skill.cooldownTimer = Mathf.Clamp(skill.cooldownDuration - elapsed, 0, skill.cooldownDuration);
            skill.cooldownOverlay.fillAmount = 1f - (elapsed / skill.cooldownDuration);
            yield return null;
        }

        skill.cooldownTimer = 0;
        skill.cooldownOverlay.gameObject.SetActive(false);
    }


}



