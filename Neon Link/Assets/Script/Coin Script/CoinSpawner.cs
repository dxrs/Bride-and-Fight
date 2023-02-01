using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    
    public float spawnTime;
    public float spawnRadius;
    [SerializeField] GameObject radiusObj;

    int curLevel;
    void Start()
    {
        curLevel = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]);
        if (UIStartGame.uIStartGame.idLevel == curLevel) 
        {
            StartCoroutine(spawnCoin());
        }
       
    }

    IEnumerator spawnCoin()
    {
        while (true && SceneManagerStatus.sceneManagerStatus.sceneStats=="Level")
        {
            if (GameStarting.gameStarting.isGameStarted &&
                !GameOver.gameOver.isGameOver
                && !GameFinish.gameFinish.isGameFinished)
            {
                yield return new WaitForSeconds(3);
                Vector2 spawnPos = radiusObj.transform.position;
                spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
                Instantiate(coin, spawnPos, Quaternion.identity);
            }
            if (UIStartGame.uIStartGame.idLevel == curLevel) 
            {
                yield return new WaitForSeconds(spawnTime);
            }
           



        }
    }
}
