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
        [HideInInspector] public float cooldownTimer;
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

        // Update cooldowns and overlays
        foreach (var skill in skills)
        {
            if (skill.cooldownTimer > 0)
            {
                skill.cooldownTimer -= Time.deltaTime;
                skill.cooldownOverlay.fillAmount = skill.cooldownTimer / skill.cooldownDuration;

                if (!skill.cooldownOverlay.gameObject.activeSelf)
                    skill.cooldownOverlay.gameObject.SetActive(true);
            }
            else if (skill.cooldownOverlay.gameObject.activeSelf)
            {
                skill.cooldownOverlay.gameObject.SetActive(false);
                skill.cooldownOverlay.fillAmount = 0f; // Reset overlay to ensure visual accuracy
            }
        }
    }

    public void UseSkill(int skillIndex)
    {
        if (skillIndex < 0 || skillIndex >= skills.Length) 
        {
            return;
        }

        Skill skill = skills[skillIndex];

        // Check if skill is on cooldown
        if (skill.cooldownTimer > 0)
        {
            // Prevent further execution if the skill is on cooldown
            return;
        }

        // Check if player has enough mana
        if (playerStats.currentMana < skill.manaCost)
        {
            // Debug.Log($"Not enough mana to use {skill.skillName}!");
            return;
        }

        // Deduct mana and start cooldown
        playerStats.UseMana(skill.manaCost);
        skill.cooldownTimer = skill.cooldownDuration;

        // Initialize the visual cooldown overlay
        skill.cooldownOverlay.fillAmount = 1f;

        // Debug.Log($"Used skill: {skill.skillName}, Mana Cost: {skill.manaCost}");
    }
}



