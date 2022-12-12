using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityStoneAbility : MonoBehaviour
{
    public static InfinityStoneAbility infinityStone;

    public int maxStoneValue;

    public float stoneTimerSpawn;

    [SerializeField] int curUpLevelValue = 1;

    [SerializeField] Transform player1;
    [SerializeField] Transform player2;

    [SerializeField] GameObject p1StoneColider;
    [SerializeField] GameObject p2StoneColider;

    private void Awake()
    {
        infinityStone = this;
    }
    private void Start()
    {
        p1StoneColider.SetActive(false);
        p2StoneColider.SetActive(false);
    }
    private void Update()
    {
        if (!GameOver.gameOver.isGameOver) 
        {
            p1StoneColider.transform.position = player1.transform.position;
            p2StoneColider.transform.position = player2.transform.position;
            p1StoneColider.transform.Rotate(Vector3.forward, 150 * Time.deltaTime);
            p2StoneColider.transform.Rotate(-Vector3.forward, 150 * Time.deltaTime);
        }
        else 
        {
            Destroy(p1StoneColider);
            Destroy(p2StoneColider);
        }
      
        enableAbility();
    }
    void enableAbility() 
    {
        if (GameStarting.gameStarting.isGameStarted) 
        {
            if (AbilitySelector.abilitySelector.abilitySelected == 1)
            {
                p1StoneColider.SetActive(true);
                p2StoneColider.SetActive(true);
            }
        }
       
    }

    //Ability Upgrade
    #region

    #endregion
}
