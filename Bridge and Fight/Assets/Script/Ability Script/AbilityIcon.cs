using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    public Image abilityIcon_kiri;
    public Image abilityIcon_kanan;
    public Image abilityIcon_inGame;


   
    private void Update()
    {
        abilityIcon_kiri.sprite = Resources.Load<Sprite>("A"+ AbilityInventory.abilityInventory.skill_1);
        abilityIcon_kanan.sprite = Resources.Load<Sprite>("A" + AbilityInventory.abilityInventory.skill_2);
        imgAbilityInGame();
    }

    void imgAbilityInGame() 
    {
        if (GameStarting.gameStarting.isGameStarted) 
        {
            abilityIcon_inGame.enabled = true;
            abilityIcon_inGame.sprite = Resources.Load<Sprite>("A" + AbilitySelector.abilitySelector.abilitySelected);
        }
        
    }
   
}
