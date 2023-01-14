using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigBallAbilitySpawner : MonoBehaviour
{
    public static BigBallAbilitySpawner bigBallAbilitySpawner;


    [SerializeField] GameObject player;
    [SerializeField] GameObject bigBall;

    [SerializeField] Image imgAbilityIcon;

    [SerializeField] int curUpLevelValue;

    string abilityName = "Slow Ride";
    private void Awake()
    {
        bigBallAbilitySpawner = this;
    }
    private void Start()
    {

        curUpLevelValue= PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[11]);

        UIStartGame.uIStartGame.abilityLeftName[3] = abilityName;
        UIStartGame.uIStartGame.abilityRightName[3] = abilityName;
      
    }
    private void Update()
    {
        if (GameStarting.gameStarting.isGameStarted && UIStartGame.uIStartGame.abilitySelectedValue == 3)
        {
            imgAbilityIcon.enabled = true;
            imgAbilityIcon.sprite = Resources.Load<Sprite>("Sprite/Ability Icon/Slow Ride/SR" + curUpLevelValue);
        }
        if (!GameOver.gameOver.isGameOver
             && GameStarting.gameStarting.isGameStarted
             && !GamePaused.gamePaused.isGamePaused
             && !GameFinish.gameFinish.isGameFinished
             && UIStartGame.uIStartGame.abilitySelectedValue == 3) 
        {
            
            if (player != null)
            {
                transform.localPosition = player.transform.position;
            }
        }
        else 
        {
            gameObject.SetActive(false);
        }
    
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Normal Enemy" || collision.gameObject.tag == "Medium Enemy")
        {
            Instantiate(bigBall, transform.localPosition, Quaternion.identity);
        }
    }
}
