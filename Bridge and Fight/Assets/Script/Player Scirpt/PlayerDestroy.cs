using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public static PlayerDestroy playerDestroy;

    public GameObject player;
    
    public ParticleSystem destroyParticle;

    private void Awake()
    {
        if (playerDestroy == null) { playerDestroy = this; }
    }

    private void Update()
    {
        if (GameOver.gameOver.isGameOver) 
        {
            Destroy(player);
        }
    }

    private void OnDestroy()
    {
        if (GameOver.gameOver.isGameOver) 
        {
            Instantiate(destroyParticle, player.transform.position, Quaternion.identity);
        }
    }

}
