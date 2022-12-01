using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius;
    public float spawnRadiusSpecial;
    public float normalTime, fastTime, slowTime;
    public GameObject enemyNormal;
    public GameObject enemyFast;
    public GameObject enemySlow;
    public GameObject player;
    //public TimerScript timer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyNormal());
        StartCoroutine(spawnEnemySlow());
        StartCoroutine(spawnEnemyFast());
    }

    IEnumerator spawnEnemyNormal()
    {
        while (true)
        {
            if (player.gameObject != null&&GameStarting.gameStarting.isGameStarted&&
                !PlayerDestroy.playerDestroy.isGameOver
                &&!GameFinish.gameFinish.isGameFinished)
            {
                Vector2 spawnPos = player.transform.position;
                spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
                Instantiate(enemyNormal, spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(normalTime);
        }
    }

    IEnumerator spawnEnemySlow()
    {
        while (true)
        {
            if (UIManager.uIManager.timerValue <= 80) 
            {
                if (player.gameObject != null && GameStarting.gameStarting.isGameStarted &&
              !PlayerDestroy.playerDestroy.isGameOver
              && !GameFinish.gameFinish.isGameFinished)
                {
                    Vector2 spawnPos = player.transform.position;
                    spawnPos += Random.insideUnitCircle.normalized * spawnRadiusSpecial;
                    Instantiate(enemySlow, spawnPos, Quaternion.identity);
                }
            }
          
            yield return new WaitForSeconds(slowTime);
        }
    }

    IEnumerator spawnEnemyFast()
    {
        while (true)
        {
            if (UIManager.uIManager.timerValue <= 60) 
            {
                if (player.gameObject != null && GameStarting.gameStarting.isGameStarted &&
                !PlayerDestroy.playerDestroy.isGameOver
                && !GameFinish.gameFinish.isGameFinished)
                {
                    Vector2 spawnPos = player.transform.position;
                    spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
                    Instantiate(enemyFast, spawnPos, Quaternion.identity);
                }
            }
           
            yield return new WaitForSeconds(fastTime);
        }
    }
}
