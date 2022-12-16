using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealBlastAbility : MonoBehaviour
{
    public static HealBlastAbility healBlastAbility;

    public bool healIsActivated;

   

    [SerializeField] int circlePlayer;

    [SerializeField] GameObject[] player;
    [SerializeField] GameObject[] healObjectList;
    [SerializeField] GameObject ringOfHeal;

    [SerializeField] bool isUsingAbility;
    [SerializeField] int curUpLevelValue;

    [SerializeField] float healingCoolDownTimer;
    [SerializeField] float healingTimer;

    [SerializeField] Image imgBar;
    [SerializeField] TextMeshProUGUI textCooldownTimer;


    [Header("Heal Blast is Moving")]
    [SerializeField] float moveSpeed;
    [SerializeField] float xMax;
    [SerializeField] float yMax;
    

    Vector2 ringScale;
    int curLevel;
    float curHealCoolDown;
    float curHealTimer;
    float curValueTimer;
    float maxValueTimer = 20;

    private void Awake()
    {
        healBlastAbility = this;
    }
    private void Start()
    {
        //curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[5]);
        circlePlayer = Random.Range(0, 2);
        ringScale = ringOfHeal.transform.localScale;
        //curUpLevelValue = curLevel;
        //healingTimer = curHealTimer;
        curValueTimer = healingTimer;
        upgradeAbilityHeal();
       
    }

    private void Update()
    {
        if (!GameOver.gameOver.isGameOver
            && GameStarting.gameStarting.isGameStarted
            && !GamePaused.gamePaused.isGamePaused
            && !GameFinish.gameFinish.isGameFinished
            && AbilitySelector.abilitySelector.abilitySelected == 2) 
        {
            
        }
        healTransform();
        healBlastMoving();
        abilityInput();
        healBar();
        textCooldownTimer.text = (int)healingCoolDownTimer + "s";
    }
    void abilityInput() 
    {
        if (PlayerNumber.playerNumber.isSoloMode)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isUsingAbility && healingCoolDownTimer <= 0)
                {
                    
                    for(int i = 0; i < healObjectList.Length; i++) 
                    {
                        healObjectList[i].SetActive(true);
                    }
                    healingCoolDownTimer = 30f;//= curHealCoolDown
                    if (!healIsActivated)
                    {
                        healIsActivated = true;
                    }
                }
            }
        }
        else 
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Abutton")) 
            {
                if (!isUsingAbility && healingCoolDownTimer <= 0)
                {
                    healingCoolDownTimer = 30f; //= curHealCoolDown
                    if (!healIsActivated)
                    {
                        healIsActivated = true;
                    }
                }
            }
            
        }
        healAcitve();
        healNotActive();
    }
    void healAcitve() 
    {
        if (healIsActivated) 
        {
            isUsingAbility = true;
            if (healingTimer > 0) 
            {
                healingTimer -= 1 * Time.deltaTime;
            }
        }
    }
    void healNotActive() 
    {
        if(healIsActivated && healingTimer <= 0) 
        {
            healIsActivated = false;
            healingTimer = 15; //= curHealingTimer
            textCooldownTimer.enabled = true;
        }
        if (!healIsActivated) { isUsingAbility = false; }

        if (!isUsingAbility) 
        {
            if (healingCoolDownTimer > 0) 
            {
                healingCoolDownTimer -= 0.5f * Time.deltaTime;

            }

        }
        if (healingCoolDownTimer <= 0) 
        {
            textCooldownTimer.enabled = false;
            healingCoolDownTimer = 0;
        }
    }

    void healBar() 
    {
        if (healIsActivated) 
        {
            imgBar.enabled = true;
        }
        else 
        {
            imgBar.enabled = false;
        }
        curValueTimer = healingTimer;
        imgBar.fillAmount = curValueTimer / maxValueTimer;
    }

    void healTransform() 
    {
        if (!GameOver.gameOver.isGameOver) 
        {
            if (circlePlayer == 0 && !healIsActivated)
            {
                ringOfHeal.transform.position = player[0].transform.position;
            }
            if (circlePlayer == 1 && !healIsActivated)
            {
                ringOfHeal.transform.position = player[1].transform.position;
            }
        }
        
        if (healIsActivated)
        {
            ringOfHeal.SetActive(true);
            ringOfHeal.transform.Rotate(Vector3.forward, 150 * Time.deltaTime);
        }
        else 
        {
            ringOfHeal.SetActive(false);
        }
    }

    void healBlastMoving() 
    {
        if(healIsActivated
            && curUpLevelValue==3) 
        {
            ringOfHeal.transform.position = ringOfHeal.transform.position + new Vector3(
            Random.Range(-1.0f, 1.0f),
            Random.Range(-1.0f, 1.0f), 0) * moveSpeed * Time.deltaTime;

            ringOfHeal.transform.position = new Vector3(Mathf.Clamp(
                ringOfHeal.transform.position.x, -xMax, xMax),
                Mathf.Clamp(ringOfHeal.transform.position.y, -yMax, yMax),
                ringOfHeal.transform.position.z);
        }
       
    }

    //upgrade ability
    #region
    void upgradeAbilityHeal() 
    {
        switch (curUpLevelValue)
        {
            case 1:
                
                break;
            case 2:
                
                break;
            case 3:
                
                break;
        }
    }
    #endregion
}
