using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager amanager;

    public AudioSource aSource;
    public AudioClip enemyDeath;
    public AudioClip pMove;
    // Start is called before the first frame update

    private void Awake()
    {
        amanager = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enemySound()
    {
        aSource.PlayOneShot(enemyDeath, 1);
    }

    public void moveSound()
    {
        aSource.PlayOneShot(pMove, 0.2f);
    }
}
