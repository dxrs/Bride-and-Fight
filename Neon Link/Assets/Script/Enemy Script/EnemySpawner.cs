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
    [SerializeField] float farmingEnemyWaitToSpawn;

    [SerializeField] bool enemyIsWaitingToSpawn;
    [SerializeField] bool isHelpingBoss;

    Vector2 enemySpawnPos;
    
    void Start()
    {
        StartCoroutine(enemyIsSpawning());
    }

    private void Update()
    {
        if(UIStartGame.uIStartGame.idLevel != PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6])) 
        {
            if (enemyIsWaitingToSpawn) 
            {
                enemyIsWaitingToSpawn = false;
            }
        }
    }


    IEnumerator enemyIsSpawning() 
    {
        while (true) 
        {
            if (GameStarting.gameStarting.isGameStarted && !GamePaused.gamePaused.isGamePaused
                    && !GameFinish.gameFinish.isGameFinished && !GameOver.gameOver.isGameOver)
            {
                if (!enemyIsWaitingToSpawn && !isHelpingBoss) // klo langsung keluar
                {
                    enemySpawnPos = spawnRadiusObject.transform.position;
                    enemySpawnPos += Random.insideUnitCircle.normalized * enemyRadiusValue;
                    Instantiate(enemy, enemySpawnPos, Quaternion.identity);
                }
                else if(enemyIsWaitingToSpawn && !isHelpingBoss) //klo ga langsung keluar
                {
                    
                    if (UIInGame.uIInGame.timerValue <= enemySpawnTimerValue) 
                    {
                        enemySpawnPos = spawnRadiusObject.transform.position;
                        enemySpawnPos += Random.insideUnitCircle.normalized * enemyRadiusValue;
                        Instantiate(enemy, enemySpawnPos, Quaternion.identity);
                    }
                    
                    
                }
                else if(!enemyIsWaitingToSpawn && isHelpingBoss) 
                {
                    if (UIStartGame.uIStartGame.idLevel == 4) 
                    {
                        if (BullBoss.bullBoss.bullBossHealth < 25) 
                        {
                            enemySpawnPos = spawnRadiusObject.transform.position;
                            enemySpawnPos += Random.insideUnitCircle.normalized * enemyRadiusValue;
                            Instantiate(enemy, enemySpawnPos, Quaternion.identity);
                        }
                    }
                }
            }

            if(UIStartGame.uIStartGame.idLevel == PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]) || isHelpingBoss) 
            {
                yield return new WaitForSeconds(enemyWaitToSpawn);
            }
            if (UIStartGame.uIStartGame.idLevel != PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]) && !isHelpingBoss)
            {
                yield return new WaitForSeconds(farmingEnemyWaitToSpawn);
            }
            
           
        }
    }

   
}
