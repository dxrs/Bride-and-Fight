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
    [SerializeField] GameObject ringOfHeal;

    [SerializeField] bool isUsingAbility;

    [SerializeField] float healingCoolDownTimer;
    [SerializeField] float healingTimer;

    [SerializeField] Image imgBar;
    [SerializeField] TextMeshProUGUI textCooldownTimer;

    Vector2 ringScale;
    float curHealCoolDown;
    float curHealTimer;
    float curValueTimer;
    float maxValueTimer = 12;

    private void Awake()
    {
        healBlastAbility = this;
    }
    private void Start()
    {
        circlePlayer = Random.Range(0, 2);
        ringScale = ringOfHeal.transform.localScale;
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

        abilityInput();
    }
    void abilityInput() 
    {
        if (PlayerNumber.playerNumber.isSoloMode)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isUsingAbility && healingCoolDownTimer <= 0)
                {
                    healingCoolDownTimer = 10f;
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
            healingTimer = 10;
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
            healingCoolDownTimer = 0;
        }
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
}
