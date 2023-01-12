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
    public Color shadowColorInner;

    

    public bool isShadowActivated;

    [SerializeField] float shadowAbilityTimer;
    [SerializeField] float shadowAblityCoolDown;

    [SerializeField] bool isUsingAbility;
    [SerializeField] bool isSlowMotion;

    [SerializeField] int curUpLevelValue;

    [SerializeField] GameObject[] wallColider;
    [SerializeField] GameObject[] coinColider;
    [SerializeField] GameObject[] player;

    [SerializeField] SpriteRenderer[] sr;

    [SerializeField] Image imgBar;
    [SerializeField] Image imgAbilityIcon;
    

    [SerializeField] TextMeshProUGUI textReady;

    

    int curLevel;
    float barUpValue = 0;
    float curShadowCooldown;
    float curShadowTimer;
    float curValueTimer;
    float maxValueTimer;
    string abilityName = "Ghost";
    private void Awake()
    {
        shadowAbility = this;
    }

    private void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[2]);
        UIStartGame.uIStartGame.abilityLeftName[0] = abilityName;
        UIStartGame.uIStartGame.abilityRightName[0] = abilityName;
    
        curUpLevelValue = curLevel;
        upgradeAbilityShadow();
        shadowAbilityTimer = curShadowTimer;
        curValueTimer = shadowAbilityTimer;
        
        
    }

    private void Update()
    {
        if (GameStarting.gameStarting.isGameStarted && UIStartGame.uIStartGame.abilitySelectedValue==0) 
        {
            imgAbilityIcon.enabled = true;
            imgAbilityIcon.sprite = Resources.Load<Sprite>("Sprite/Ability Icon/Shadow/Shadow" + curUpLevelValue);
        }
        
        if (!GameOver.gameOver.isGameOver) 
        {
            coinColider[0].transform.position = player[0].transform.position;
            coinColider[1].transform.position = player[1].transform.position;
        }
        if (!GameOver.gameOver.isGameOver
            && GameStarting.gameStarting.isGameStarted
            && !GamePaused.gamePaused.isGamePaused
            && !GameFinish.gameFinish.isGameFinished
            &&UIStartGame.uIStartGame.abilitySelectedValue==0) 
        {
            abilityInput();
            shadowBar();
            
        }

    }

    void abilityInput() 
    {
        if (PlayerNumber.playerNumber.isSoloMode) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isUsingAbility && shadowAblityCoolDown <= 0)
                {
                    imgAbilityIcon.color = new Color(0.2f, 0.2f, 0.2f);
                    shadowAblityCoolDown = curShadowCooldown;

                    barUpValue = 0;
                    textReady.enabled = false;
                    if (!isShadowActivated)
                    {
                        isShadowActivated = true;

                    }
                }
            }
        }
        if(!PlayerNumber.playerNumber.isSoloMode)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Abutton")) 
            {
                if (!isUsingAbility && shadowAblityCoolDown <= 0)
                {
                    imgAbilityIcon.color = new Color(0.2f, 0.2f, 0.2f);
                    shadowAblityCoolDown = curShadowCooldown;

                    barUpValue = 0;
                    textReady.enabled = false;
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
            sr[2].color = shadowColorInner;
            sr[3].color = shadowColorInner;

            wallColider[0].SetActive(true);
            wallColider[1].SetActive(true);

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
            
            
            
        }
        if (!isShadowActivated) 
        {
            isUsingAbility = false;

            wallColider[0].SetActive(false);
            wallColider[1].SetActive(false);

            sr[0].color = curPlayerColor_1;
            sr[1].color = curPlayerColor_2;
          
            sr[2].color = curPlayerColor_2;
            sr[3].color = curPlayerColor_1;
        }
        if (!isUsingAbility) 
        {
            if (shadowAblityCoolDown > 0) 
            {
                shadowAblityCoolDown -= 0.8f * Time.deltaTime;
            }
            if (barUpValue < 11)
            {
                barUpValue += 0.8f * Time.deltaTime;
            }
        }

        if (shadowAblityCoolDown <= 0) 
        {
            
            shadowAblityCoolDown = 0;
            imgAbilityIcon.color = new Color(1, 1, 1);
            textReady.enabled = true;
        }
    }
    void shadowBar() 
    {
        if (isShadowActivated) 
        {
            imgBar.enabled = true;
            curValueTimer = shadowAbilityTimer;
    
            imgBar.fillAmount = curValueTimer / curShadowTimer;
            
            
        }
        else 
        {
           curValueTimer = barUpValue;
           imgBar.fillAmount =curValueTimer/curShadowCooldown;
         
        }
        


    }

    //upgrade ability
    #region upgrade ability shadow
    void upgradeAbilityShadow() 
    {
        if (curUpLevelValue >= 3) 
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
               
                curShadowCooldown = 11.0f;
                break;
            case 3:
                curShadowTimer = 12.5f;
                
                curShadowCooldown = 20.0f;
                break;
        }
    }
    #endregion
}
