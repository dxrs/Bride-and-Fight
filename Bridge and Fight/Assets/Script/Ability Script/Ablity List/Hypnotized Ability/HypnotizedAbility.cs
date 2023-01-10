using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HypnotizedAbility : MonoBehaviour
{
    public static HypnotizedAbility hypnotizedAbility;

    public bool hypnotizedActivated;

    [SerializeField] GameObject[] player;
    [SerializeField] GameObject[] diamondList;
    [SerializeField] GameObject ringOfDiamond;

    [SerializeField] bool isUsingAbility;

    [SerializeField] int curUpLevelValue;

    [SerializeField] float hypnotizedCooldownTimer;
    [SerializeField] float hypnotizeActivatedTime;

    [SerializeField] Image imgBar;
    [SerializeField] TextMeshProUGUI textCooldownTimer;

    [Header("Diamond Object Moving")]
    [SerializeField] float moveSpeed;
    [SerializeField] float xMax;
    [SerializeField] float xMin;
    [SerializeField] float yMax;
    [SerializeField] float yMin;
    [SerializeField] Vector3 targetPos;
    [SerializeField] bool isMoving;

    int indexPlayer;
    int curLevel;
    float curAbilityTimer;
    float curValueTimer;
    float maxValueTimer = 20;
    string abilityName = "Mind Control";
    private void Awake()
    {
        hypnotizedAbility = this;
    }
    private void Start()
    {
        indexPlayer = Random.Range(0, 2);

        curValueTimer = hypnotizeActivatedTime;
        UIStartGame.uIStartGame.abilityLeftName[2] = abilityName;
        UIStartGame.uIStartGame.abilityRightName[2] = abilityName;
        //up method di sini

        StartCoroutine(ringOfDiamondStartMoving());
    }

    private void Update()
    {
        if(!GameOver.gameOver.isGameOver
            && GameStarting.gameStarting.isGameStarted
            && !GamePaused.gamePaused.isGamePaused
            && !GameFinish.gameFinish.isGameFinished
            && UIStartGame.uIStartGame.abilitySelectedValue == 2) 
        {
            ringOfDiamondTransform();
            if (curUpLevelValue == 3) 
            {
                ringOfDiamondMoving();
            }
            
            abilityInput();
            //hypnotizedBar();
            //textCooldownTimer.text = (int)hypnotizedCooldownTimer + "s";
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
                    for(int k=0; k < diamondList.Length; k++) 
                    {
                        diamondList[k].SetActive(true);
                    }
                    hypnotizedCooldownTimer = 5; //cur cooldown timer
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
                    for (int k = 0; k < diamondList.Length; k++)
                    {
                        diamondList[k].SetActive(true);
                    }
                    hypnotizedCooldownTimer = 30;//cur cooldown timer
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
            if (hypnotizeActivatedTime > 0) 
            {
                hypnotizeActivatedTime -= 1 * Time.deltaTime;
            }
        }
    }

    void hypnotizedNotActive() 
    {
        if(hypnotizedActivated && hypnotizeActivatedTime <= 0) 
        {
            hypnotizedActivated = false;
            hypnotizeActivatedTime = 15;//cur hypnotized timer
            //textCooldownTimer.enabled = true;

           
        }
        if (!hypnotizedActivated) { isUsingAbility = false; }

        if (!isUsingAbility) 
        {
            if (hypnotizedCooldownTimer > 0) 
            {
                hypnotizedCooldownTimer -= 0.5f * Time.deltaTime;
            }
        }

        if (hypnotizedCooldownTimer <= 0) 
        {
            //textCooldownTimer.enabled = false;
            hypnotizedCooldownTimer = 0;
        }
    }

    void hypnotizedBar() 
    {
        if (hypnotizedActivated) 
        {
            imgBar.enabled = true;
        }
        else 
        {
            imgBar.enabled = false;
        }
        curValueTimer = hypnotizeActivatedTime;
        imgBar.fillAmount = curValueTimer / maxValueTimer;
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
            ringOfDiamond.SetActive(true);
            ringOfDiamond.transform.Rotate(Vector3.forward, 150 * Time.deltaTime);
        }
        else 
        {
            ringOfDiamond.SetActive(false);
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
            if (hypnotizedActivated
                && !GameOver.gameOver.isGameOver
                && GameStarting.gameStarting.isGameStarted)
            {
                targetPos = new Vector3(Random.Range(xMin, xMax),
                   Random.Range(yMin, yMax), 0);
                isMoving = true;
            }
        }
    }
    #endregion
}
