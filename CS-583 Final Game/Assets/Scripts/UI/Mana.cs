using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Slider manaSlider; 
    private int maxMana;

    // Initialize mana bar 
    public void InitializeBars(int maxMana)
    {
        this.maxMana = maxMana;
        manaSlider.maxValue = maxMana;
        manaSlider.value = maxMana;
    }

    // Update the mana bar
    public void UpdateManaBar(int currentMana)
    {
        manaSlider.value = currentMana;
    }
}

