using UnityEngine;
using UnityEngine.UI;

public class SkillCooldown: MonoBehaviour
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
        // Change change input to something else if needed
        // Check for keyboard input
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseSkill(0); // Press 1 for the first skill
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseSkill(1); // Press 2 for the second skill
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseSkill(2); // Press 3 for the third skill
        if (Input.GetKeyDown(KeyCode.Alpha4)) UseSkill(3); // Press 4 for the fourth skill

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

        // Check if player has enough mana
        if (playerStats.currentMana < skill.manaCost)
        {
            //Debug.Log($"Not enough mana to use {skill.skillName}!");
            return;
        }

        // Check if skill is on cooldown
        if (skill.cooldownTimer > 0)
        {
            //Debug.Log($"{skill.skillName} is on cooldown!");
            return;
        }

        // Deduct mana and start cooldown
        playerStats.UseMana(skill.manaCost);
        skill.cooldownTimer = skill.cooldownDuration;

        //Debug.Log($"Used skill: {skill.skillName}, Mana Cost: {skill.manaCost}");
    }
}


