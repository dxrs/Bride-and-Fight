using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullBossSpike : MonoBehaviour
{
    PolygonCollider2D pc;


    private void Start()
    {
        transform.localScale = new Vector2(0, 0);
        pc = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        if (BullBoss.bullBoss.isSpikeSpawn) 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(1, 1), 1 * Time.deltaTime);
        }
        else 
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, new Vector2(0, 0), 0.5f * Time.deltaTime);
        }

        if (transform.localScale.x <= 0) 
        {
            pc.enabled = false;
        }
        if (transform.localScale.x == 1) 
        {
            pc.enabled = true;
        }
    }

    
}
