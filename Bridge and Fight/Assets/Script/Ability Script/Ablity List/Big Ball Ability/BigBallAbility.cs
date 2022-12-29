using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallAbility : MonoBehaviour
{
    [SerializeField] Vector2 maxScale;

    [SerializeField] float blastSpeed;


    private void Start()
    {
        //Destroy(gameObject,5f);
    }

    private void Update()
    {
        transform.localScale = Vector2.MoveTowards(transform.localScale,
            maxScale, blastSpeed * Time.deltaTime);


        if (transform.localScale.x >= maxScale.x) 
        {
            Destroy(gameObject,1);
        }
    }

    IEnumerator destroyBigBall() 
    {
        while (true) 
        {
            //if(transform.localScale.x>=)
        }
    }
}
