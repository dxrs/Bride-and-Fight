using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HypnotizedAbility : MonoBehaviour
{
    public static HypnotizedAbility hypnotizedAbility;

    public bool hypnotizedActivated;

    public int curEnemyHitValue;

    [SerializeField] GameObject[] player;
    [SerializeField] GameObject ringOfDiamond;

    [SerializeField] bool isUsingAbility;

    [SerializeField] int curUpLevelValue;


    [SerializeField] float hypnotizedCooldownTimer;
    [SerializeField] float hypnotizeActivatedTimer;
    [SerializeField] float barUpValue;

    [SerializeField] Image imgBar;
    [SerializeField] Image imgAbilityIcon;

    [SerializeField] CircleCollider2D cc;
 
    [SerializeField] TextMeshProUGUI textReady;

    [Header("Diamond Object Moving")]
    [SerializeField] float moveSpeed;
    [SerializeField] float xMax;
    [SerializeField] float xMin;
    [SerializeField] float yMax;
    [SerializeField] float yMin;
    [SerializeField] Vector3 targetPos;
    [SerializeField] bool isMoving;

    int maxEnemyHit;
    int indexPlayer;
    int curUpLevel;
    float coolDownFixValue;
    float curMindControlTimer;
    float curValueTimer;
    string abilityName = "Hypnotic";
    bool isSoundStart = true;
    private void Awake()
    {
        hypnotizedAbility = this;
    }
    private void Start()
    {
        curUpLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[5]);
        indexPlayer = Random.Range(0, 2);

        coolDownFixValue = 30;
        UIStartGame.uIStartGame.abilityLeftName[2] = abilityName;
        UIStartGame.uIStartGame.abilityRightName[2] = abilityName;
        curUpLevelValue = curUpLevel;
        curEnemyHitValue = 0;
        if (curUpLevelValue == 1)
        {
            maxEnemyHit = 5;
            curMindControlTimer = 15;
        }
        if (curUpLevelValue == 2)
        {
            maxEnemyHit = 7;
            curMindControlTimer = 17;
        }
        if (curUpLevelValue == 3)
        {
            maxEnemyHit = 10;
            curMindControlTimer = 18;
        }
        hypnotizeActivatedTimer = curMindControlTimer;
        //curValueTimer = hypnotizeActivatedTimer;
        StartCoroutine(ringOfDiamondStartMoving());

        
    }

    private void Update()
    {
        if (GameStarting.gameStarting.isGameStarted && UIStartGame.uIStartGame.abilitySelectedValue == 2)
        {
            imgAbilityIcon.enabled = true;
            imgAbilityIcon.sprite = Resources.Load<Sprite>("Sprite/Ability Icon/Mind Control/MC" + curUpLevelValue);
            imgBar.sprite = imgAbilityIcon.sprite;
        }
        if (!GameOver.gameOver.isGameOver
            && GameStarting.gameStarting.isGameStarted
            && !GamePaused.gamePaused.isGamePaused
            && !GameFinish.gameFinish.isGameFinished
            && UIStartGame.uIStartGame.abilitySelectedValue == 2) 
        {
            ringOfDiamond.SetActive(true);
            ringOfDiamondTransform();
            if (curUpLevelValue == 3) 
            {
                ringOfDiamondMoving();
            }
            
            abilityInput();
            hypnotizedBar();
           
        }
    }

    void abilityInput() 
    {
        if (PlayerNumber.playerNumber.isSoloMode) 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                if(!isUsingAbility && hypnotizedCooldownTimer <= 0)
                {
                    
                    SoundEffect.soundEffect.audioSources[13].Play();
                    imgAbilityIcon.color = new Color(0.2f, 0.2f, 0.2f);
                    barUpValue = 0;
                    textReady.enabled = false;

                   
                    
                    hypnotizedCooldownTimer = 30; //cur cooldown timer
                    isSoundStart = false;
                    if (!hypnotizedActivated) 
                    {
                        hypnotizedActivated = true;
                    }
                }
            }
        }
        else 
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Abutton")) 
            {
                if (!isUsingAbility && hypnotizedCooldownTimer <= 0)
                {
                    SoundEffect.soundEffect.audioSources[13].Play();
                    imgAbilityIcon.color = new Color(0.2f, 0.2f, 0.2f);
                    barUpValue = 0;
                    textReady.enabled = false;
                   
                    hypnotizedCooldownTimer = 30;//cur cooldown timer
                    isSoundStart = false;
                    if (!hypnotizedActivated)
                    {
                        hypnotizedActivated = true;
                    }
                }
            }
        }

        hypnotizedActive();
        hypnotizedNotActive();
    }

    void hypnotizedActive() 
    {
        if (hypnotizedActivated) 
        {
            isUsingAbility = true;
            if (hypnotizeActivatedTimer > 0) 
            {
                hypnotizeActivatedTimer -= 1 * Time.deltaTime;
            }
        }
    }

    void hypnotizedNotActive() 
    {
        if (hypnotizedActivated) 
        {
            if (curEnemyHitValue >= maxEnemyHit || hypnotizeActivatedTimer <= 0)
            {
                hypnotizedActivated = false;
                hypnotizeActivatedTimer = curMindControlTimer;//cur hypnotized timer
                curEnemyHitValue = 0;


            }
        }
       
        if (!hypnotizedActivated) { isUsingAbility = false; }

        if (!isUsingAbility) 
        {
            if (hypnotizedCooldownTimer > 0) 
            {
                hypnotizedCooldownTimer -= 1f * Time.deltaTime;
                
            }

            
        }

        if (hypnotizedCooldownTimer <= 0) 
        {
            hypnotizedCooldownTimer = 0;
            imgAbilityIcon.color = new Color(1, 1, 1);
            textReady.enabled = true;
            if (!isSoundStart) 
            {
                SoundEffect.soundEffect.audioSources[12].Play();
                isSoundStart = true;
            }
        }
        
    }

    void hypnotizedBar() 
    {
        if (hypnotizedActivated) 
        {
            imgBar.enabled = true;
            curValueTimer = hypnotizeActivatedTimer;

            imgBar.fillAmount = curValueTimer / curMindControlTimer;
        }
        else 
        {
            if(!isUsingAbility && hypnotizedCooldownTimer > 0)
            {
                barUpValue += 1f * Time.deltaTime;
                imgBar.fillAmount = barUpValue / coolDownFixValue;
                
            }
       
   
        }
       
    }

    void ringOfDiamondTransform() 
    {
        if (indexPlayer == 0 && !hypnotizedActivated) 
        {
            ringOfDiamond.transform.position = player[0].transform.position;

        }
        if (indexPlayer == 1 && !hypnotizedActivated) 
        {
            ringOfDiamond.transform.position = player[1].transform.position;
        }

        if (hypnotizedActivated) 
        {
            ringOfDiamond.transform.localScale = Vector2.MoveTowards(ringOfDiamond.transform.localScale, new Vector2(1, 1), 3 * Time.deltaTime);
            if (ringOfDiamond.transform.localScale.x == 1) 
            {
                cc.enabled = true;
            }

            //ringOfDiamond.SetActive(true);
            ringOfDiamond.transform.Rotate(Vector3.forward, 150 * Time.deltaTime);
        }
        else 
        {
            ringOfDiamond.transform.localScale = Vector2.MoveTowards(ringOfDiamond.transform.localScale, new Vector2(0, 0), 5f * Time.deltaTime);
            cc.enabled = false;
            ringOfDiamond.transform.Rotate(-Vector3.forward, 150 * Time.deltaTime);
            //ringOfDiamond.SetActive(false);
        }
    }

    #region ring of diamond is moving
    void ringOfDiamondMoving() 
    {
        if (isMoving) 
        {
            ringOfDiamond.transform.localPosition = Vector3.MoveTowards(ringOfDiamond.transform.localPosition,
                targetPos, moveSpeed * Time.deltaTime);

            if (ringOfDiamond.transform.localPosition == targetPos) 
            {
                isMoving = false;
            }
        }
    }

    IEnumerator ringOfDiamondStartMoving() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1.5f);
            if (curUpLevelValue == 3) 
            {
                if (hypnotizedActivated
               && !GameOver.gameOver.isGameOver
               && GameStarting.gameStarting.isGameStarted)
                {
                    if (ringOfDiamond.transform.localScale.x == 1) 
                    {
                        targetPos = new Vector3(Random.Range(xMin, xMax),
                      Random.Range(yMin, yMax), 0);
                        isMoving = true;
                    }
                   
                }
            }
           
        }
    }
    #endregion
}
