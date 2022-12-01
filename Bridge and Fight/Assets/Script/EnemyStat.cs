using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{

    public static EnemyStat enemyStat;

    public float speed;
    public float health;

    public AudioSource aSource;
    public AudioClip clipNya;

    public ParticleSystem enemyParticle;

    void Update()
    {
        if(health <= 0)
        {
            enemyMati();
        }
    }

    public void enemyMati()
    {
        audioManager.amanager.enemySound();
        Destroy(this.gameObject);
        Instantiate(enemyParticle, transform.position, Quaternion.identity);
    }
}
