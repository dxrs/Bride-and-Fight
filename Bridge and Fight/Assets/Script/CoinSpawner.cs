using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public GameObject player;
    public float spawnTime;
    public float spawnRadius;
    void Start()
    {
        StartCoroutine(spawnCoin());
    }

    IEnumerator spawnCoin()
    {
        while (true)
        {
            Vector2 spawnPos = player.transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(coin, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
