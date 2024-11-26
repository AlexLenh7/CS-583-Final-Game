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
        [HideInInspector] public float cooldownTimer;
    }

    public Skill[] skills;

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
            Debug.LogWarning("Invalid skill index");
            return;
        }

        var skill = skills[skillIndex];
        if (skill.cooldownTimer <= 0)
        {
            // Trigger the skill (logic for skill activation goes here)
            Debug.Log($"Skill {skill.skillName} activated!");

            // Start cooldown
            skill.cooldownTimer = skill.cooldownDuration;
        }
        else
        {
            Debug.Log($"Skill {skill.skillName} is on cooldown!");
        }
    }
}


