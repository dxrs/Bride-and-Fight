using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    
    public float spawnTime;
    public float spawnRadius;
    [SerializeField] GameObject radiusObj;
    void Start()
    {
        StartCoroutine(spawnCoin());
    }

    IEnumerator spawnCoin()
    {
        while (true)
        {
            if(GameStarting.gameStarting.isGameStarted &&
                !GameOver.gameOver.isGameOver) 
            {
                Vector2 spawnPos = radiusObj.transform.position;
                spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
                Instantiate(coin, spawnPos, Quaternion.identity);
            }
           
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
