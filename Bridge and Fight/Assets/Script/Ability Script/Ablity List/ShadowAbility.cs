using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShadowAbility : MonoBehaviour
{
    public static ShadowAbility shadowAbility;

    public Color curPlayerColor_1;
    public Color curPlayerColor_2;
    public Color shadowColor;

    public bool isShadowActivated;

    [SerializeField] float shadowAbilityTimer;
    [SerializeField] float shadowAblityCoolDown;

    [SerializeField] bool isUsingAbility;
    [SerializeField] int curUpLevelValue=1;

    [SerializeField] GameObject[] coinColider;
    [SerializeField] GameObject[] player;
    [SerializeField] SpriteRenderer[] sr;
    [SerializeField] Image imgBar;
    [SerializeField] TextMeshProUGUI textCooldownTimer;

    float curShadowCooldown;
    float curShadowTimer;
    float curValueTimer;
    float maxValueTimer = 12;

    private void Awake()
    {
        shadowAbility = this;
    }

    private void Start()
    {
        upgradeAbilityShadow();
        shadowAbilityTimer = curShadowTimer;
        curValueTimer = shadowAbilityTimer;
        
    }

    private void Update()
    {
        if (!GameOver.gameOver.isGameOver) 
        {
            coinColider[0].transform.position = player[0].transform.position;
            coinColider[1].transform.position = player[1].transform.position;
        }
        if (!GameOver.gameOver.isGameOver
            && GameStarting.gameStarting.isGameStarted
            && !GamePaused.gamePaused.isGamePaused
            && !GameFinish.gameFinish.isGameFinished
            &&AbilitySelector.abilitySelector.abilitySelected==0) 
        {
            abilityInput();
        }
        shadowBar();
        textCooldownTimer.text = (int)shadowAblityCoolDown + "s";
    }

    void abilityInput() 
    {
        if (PlayerNumber.playerNumber.isSoloMode) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isUsingAbility && shadowAblityCoolDown <= 0)
                {

                    shadowAblityCoolDown = curShadowCooldown;
                    if (!isShadowActivated)
                    {
                        isShadowActivated = true;

                    }
                }
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Abutton")) 
            {
                if (!isUsingAbility && shadowAblityCoolDown <= 0)
                {

                    shadowAblityCoolDown = curShadowCooldown;
                    if (!isShadowActivated)
                    {
                        isShadowActivated = true;

                    }
                }
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
            shadowAbilityTimer = curShadowTimer;
            textCooldownTimer.enabled = true;
            
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
                shadowAblityCoolDown -= 0.8f * Time.deltaTime;
            }
        }

        if (shadowAblityCoolDown <= 0) 
        {
            textCooldownTimer.enabled = false;
            shadowAblityCoolDown = 0;
        }
    }
    void shadowBar() 
    {
        if (isShadowActivated) 
        {
            imgBar.enabled = true;
        }
        else 
        {
            imgBar.enabled = false;
        }
        curValueTimer = shadowAbilityTimer;
        imgBar.fillAmount = curValueTimer / maxValueTimer;


    }

    //upgrade ability
    #region
    void upgradeAbilityShadow() 
    {
        if (curUpLevelValue >= 2) 
        {
            coinColider[0].SetActive(true);
            coinColider[1].SetActive(true);
        }
        switch (curUpLevelValue) 
        {
            case 1:
                curShadowTimer = 5;
                curShadowCooldown = 11.0f;
                break;
            case 2:
                curShadowTimer = 10;
                break;
            case 3:
                curShadowTimer = 12.5f;
                curShadowCooldown = 16.0f;
                break;
        }
    }
    #endregion
}
