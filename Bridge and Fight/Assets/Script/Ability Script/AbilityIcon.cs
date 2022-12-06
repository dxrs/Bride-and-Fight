using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    public Image[] abilityIcon_kiri;
    public Image[] abilityIcon_kanan;

    private void Start()
    {
      
    }
    private void Update()
    {
        iconKiri();
        iconKanan();
    }
    void iconKiri() 
    {
        if (AbilityInventory.abilityInventory.skill_1 == 0) 
        {
            abilityIcon_kiri[0].enabled = true;
            abilityIcon_kiri[1].enabled = false;
        }
        if(AbilityInventory.abilityInventory.skill_1 == 1) 
        {
            abilityIcon_kiri[1].enabled = true;
            abilityIcon_kiri[0].enabled = false;
        }
    }

    void iconKanan() 
    {
        if (AbilityInventory.abilityInventory.skill_2 == 0) 
        {
            abilityIcon_kanan[0].enabled = true;
            abilityIcon_kanan[1].enabled = false;
        }
        if(AbilityInventory.abilityInventory.skill_2 == 1) 
        {
            abilityIcon_kanan[1].enabled = true;
            abilityIcon_kanan[0].enabled = false;
        }
    }
}
