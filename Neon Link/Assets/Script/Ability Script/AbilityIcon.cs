using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityIcon : MonoBehaviour
{
    public Image abilityIcon_kiri;
    public Image abilityIcon_kanan;
    public Image abilityIcon_inGame;

    [SerializeField] TextMeshProUGUI textAbilityKiri;
    [SerializeField] TextMeshProUGUI textAbilityKanan;

    [SerializeField] string[] namaAbilityKanan;
    [SerializeField] string[] namaAbilityKiri;

   
    private void Update()
    {
        abilityIcon_kiri.sprite = Resources.Load<Sprite>("Sprite/Ability Sprite/A"+ AbilityInventory.abilityInventory.skill_1);
        abilityIcon_kanan.sprite = Resources.Load<Sprite>("Sprite/Ability Sprite/A" + AbilityInventory.abilityInventory.skill_2);

        for (int i = 0; i < namaAbilityKanan.Length; i++)
        {
            //textAbilityKanan.text = (AbilityInventory.abilityInventory.skill_1 == i) ? namaAbilityKanan[i] : "";
            if (AbilityInventory.abilityInventory.skill_1 == i) 
            {
                textAbilityKanan.text = namaAbilityKanan[i];
                break;
            }
            else 
            {
                textAbilityKanan.text = "";
            }
        }
        for (int j = 0; j < namaAbilityKiri.Length; j++)
        {
            if (AbilityInventory.abilityInventory.skill_2 == j)
            {
                textAbilityKiri.text = namaAbilityKiri[j];
                break;
            }
            else
            {
                textAbilityKiri.text = "";
            }
        }

        imgAbilityInGame();
    }

    void imgAbilityInGame() 
    {
        if (GameStarting.gameStarting.isGameStarted) 
        {
            abilityIcon_inGame.enabled = true;
            //abilityIcon_inGame.sprite = Resources.Load<Sprite>("Sprite/Ability Icon/A" + AbilitySelector.abilitySelector.abilitySelected);
        }
        
    }
   
}
