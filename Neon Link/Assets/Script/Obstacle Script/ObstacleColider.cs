using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColider : MonoBehaviour
{
    BoxCollider2D bc;
    PolygonCollider2D pc;
    CircleCollider2D cc;
    CapsuleCollider2D co;

    [SerializeField] string id;

    private void Start()
    {
       
        bc = GetComponent<BoxCollider2D>();
        pc = GetComponent<PolygonCollider2D>();
        cc = GetComponent<CircleCollider2D>();
        co = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (GameFinish.gameFinish.isGameFinished)
        {
          
           
            
            

            if (id == "BC") 
            {
                bc.enabled = false;
            }
            if (id == "PC") 
            {
                pc.enabled = false;
            }
            if (id == "CC") 
            {
                cc.enabled = false;
            }
            if (id == "CO") 
            {
                co.enabled = false;
            }

        }
        
    }

}
