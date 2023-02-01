using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBossDestroy : MonoBehaviour
{
    public static BullBossDestroy bullBossDestroy;

    public bool isBullBossDestroyed;

    [SerializeField] ParticleSystem destroyParticle;

    private void Awake()
    {
        if (bullBossDestroy == null) { bullBossDestroy = this; }
    }
    private void Update()
    {
        if (BullBoss.bullBoss.bullBossHealth <= 0) 
        {
            GameFinish.gameFinish.isGameFinished = true;
            isBullBossDestroyed = true;
            BullBoss.bullBoss.bullBossHealth = 0;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (isBullBossDestroyed) 
        {
            Instantiate(destroyParticle, transform.position, Quaternion.identity);
            if (PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[6]) == 4) 
            {
                TotalCoin.totalCoin.curCoinGet += 100;
            }
        }
    }
}
