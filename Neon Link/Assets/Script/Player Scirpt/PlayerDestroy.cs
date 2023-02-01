using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerDestroy : MonoBehaviour
{
    public static PlayerDestroy playerDestroy;

    public GameObject player;
    
    public ParticleSystem destroyParticle;
    Vector2 targetScale = Vector2.zero;

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
        if (GameFinish.gameFinish.isGameFinished) 
        {
            StartCoroutine(waitToScale());
        }
    }
    IEnumerator waitToScale() 
    {
        yield return new WaitForSeconds(1);
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, 1.5f * Time.deltaTime);
    }

    
    private void OnDestroy()
    {
        if (gameObject != null) 
        {
            CameraShaker.Instance.ShakeOnce(4, 4, .1f, 1);
        }
        if (GameOver.gameOver.isGameOver) 
        {
            Instantiate(destroyParticle, player.transform.position, Quaternion.identity);
            

        }
    }

}
