using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAbility : MonoBehaviour
{
    public static ShadowAbility shadowAbility;

    public Color curPlayerColor_1;
    public Color curPlayerColor_2;
    public Color shadowColor;

    public bool isShadowActivated;

    public float shadowAbilityTimer;
    public float shadowAblityCoolDown;

    [SerializeField] bool isUsingAbility;


    [SerializeField] SpriteRenderer[] sr;

    private void Awake()
    {
        shadowAbility = this;
    }

    private void Update()
    {
        if (!PlayerDestroy.playerDestroy.isGameOver
            &&AbilitySelector.abilitySelector.abilitySelected==0) 
        {
            abilityInput();
        }
        
    }

    void abilityInput() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isUsingAbility
            &&shadowAblityCoolDown<=0) 
        {
           
            shadowAblityCoolDown = 10;
            if (!isShadowActivated)
            {
                isShadowActivated = true;
            }
        }
        shadowActivated();
        shadowNotActive();
       
    }

    void shadowActivated() 
    {
        if (isShadowActivated) 
        {
            
            sr[0].color = shadowColor;
            sr[1].color = shadowColor;
            isUsingAbility = true;
            if (shadowAbilityTimer > 0) 
            {
                shadowAbilityTimer -= 1 * Time.deltaTime;
            }
        }
    }

    void shadowNotActive() 
    {
        if (isShadowActivated && shadowAbilityTimer <= 0) 
        {
            isShadowActivated = false;
            shadowAbilityTimer = 10.0f;
        }
        if (!isShadowActivated) 
        {
            isUsingAbility = false;
           
            sr[0].color = curPlayerColor_1;
            sr[1].color = curPlayerColor_2;
        }
        if (!isUsingAbility) 
        {
            if (shadowAblityCoolDown > 0) 
            {
                shadowAblityCoolDown -= 0.3f * Time.deltaTime;
            }
        }

        if (shadowAblityCoolDown <= 0) 
        {
            shadowAblityCoolDown = 0;
        }
    }
}
