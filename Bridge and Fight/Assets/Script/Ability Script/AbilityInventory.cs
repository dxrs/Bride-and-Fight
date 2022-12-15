using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityInventory : MonoBehaviour
{
    public static AbilityInventory abilityInventory;

    // nilai dari button random antara 1-jumlah skill yang ke buka
    public int maxTotalSkill;
    public int skill_1;
    public int skill_2;

   

    private void Awake()
    {
        abilityInventory = this;
    }

    private void Start()
    {
        skill_1 = Random.Range(0, maxTotalSkill);
        skill_2 = Random.Range(0, maxTotalSkill);

        // Pastikan skill_1 dan skill_2 tidak sama
        if (skill_1 == skill_2)
        {
            // Generate angka acak untuk skill_2 sampai tidak sama dengan skill_1
            while (skill_1 == skill_2)
            {
                skill_2 = Random.Range(0, maxTotalSkill);
            }
        }
    }
    

}
