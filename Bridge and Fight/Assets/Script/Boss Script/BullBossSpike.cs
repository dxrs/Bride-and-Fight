using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBossSpike : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector2(0, 0);
    }
    private void Update()
    {
        if (BullBoss.bullBoss.isSpikeSpawn) 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(1, 1), 0.5f * Time.deltaTime);
        }
        else 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(0, 0), 0.5f * Time.deltaTime);
        }
    }

    
}
