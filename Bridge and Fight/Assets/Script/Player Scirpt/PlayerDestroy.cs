using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public static PlayerDestroy playerDestroy;

    public GameObject p1, p2;
    public bool isGameOver;
    public ParticleSystem destroyParticle;

    private void Awake()
    {
        playerDestroy = this;
    }

    private void Update()
    {
        if (isGameOver)  
        {
            Destroy(p1);
            Destroy(p2);
        }
    }

    private void OnDestroy()
    {
        
    }

}
