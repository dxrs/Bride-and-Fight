using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfRay : MonoBehaviour
{

    public static LineOfRay lineOfRay;

    

    public bool isTouchObstcale;

    public Transform[] lineTargets;
    public LayerMask layerMask;

    
    private void Awake()
    {
        if (lineOfRay == null) { lineOfRay = this; }
    }

    // Update is called once per frame
    void Update()
    {
        if (UIStartGame.uIStartGame.levelType == "survive")
        {
            if (!GameOver.gameOver.isGameOver && !ShadowAbility.shadowAbility.isShadowActivated)
            {
                lineConnector();
            }

        }
       

      


       
    }

    void lineConnector() 
    {
        RaycastHit2D hit = Physics2D.Linecast(lineTargets[0].transform.position, lineTargets[1].transform.position, layerMask);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "obstacle")
            {
                
                Debug.DrawLine(lineTargets[0].transform.position, lineTargets[1].position, Color.red);
                isTouchObstcale = true;
            }
           
          
            else
            {
                
                Debug.DrawLine(lineTargets[0].transform.position, lineTargets[1].position, Color.green);
                isTouchObstcale = false;
                
            }

           
        }
    }


}
