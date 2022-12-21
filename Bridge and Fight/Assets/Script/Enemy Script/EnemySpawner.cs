using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject spawnRadiusObject;

    [SerializeField] float enemyRadiusValue;
    [SerializeField] float enemySpawnTimerValue;
    [SerializeField] float enemyWaitToSpawn;

    [SerializeField] bool enemyIsWaitingToSpawn;

    Vector2 enemySpawnPos;
    
    void Start()
    {
        StartCoroutine(enemyIsSpawning());
    }


    IEnumerator enemyIsSpawning() 
    {
        while (true) 
        {
            if (GameStarting.gameStarting.isGameStarted && !GamePaused.gamePaused.isGamePaused
                    && !GameFinish.gameFinish.isGameFinished && !GameOver.gameOver.isGameOver)
            {
                if (!enemyIsWaitingToSpawn) // klo langsung keluar
                {
                    enemySpawnPos = spawnRadiusObject.transform.position;
                    enemySpawnPos += Random.insideUnitCircle.normalized * enemyRadiusValue;
                    Instantiate(enemy, enemySpawnPos, Quaternion.identity);
                }
                else //klo ga langsung keluar
                {
                    if (UIManager.uIManager.timerValue <= enemySpawnTimerValue) 
                    {
                        enemySpawnPos = spawnRadiusObject.transform.position;
                        enemySpawnPos += Random.insideUnitCircle.normalized * enemyRadiusValue;
                        Instantiate(enemy, enemySpawnPos, Quaternion.identity);
                    }
                }
            }
            yield return new WaitForSeconds(enemyWaitToSpawn);
           
        }
    }

   
}
