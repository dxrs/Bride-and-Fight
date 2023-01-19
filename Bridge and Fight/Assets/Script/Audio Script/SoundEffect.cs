using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static SoundEffect soundEffect;

    public AudioSource[] audioSources;
    public AudioClip[] audioClips;
 
    [SerializeField] int soundValueData;

    [SerializeField] GameObject objectSoundEffect;

    private void Awake()
    {
        soundEffect = this;
    }

    private void Start()
    {
        soundValueData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[9]);
    }

   
    private void OnEnable()
    {
        if (soundValueData == 1) 
        {
            objectSoundEffect.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (soundValueData == 0) 
        {
            objectSoundEffect.SetActive(false);
        }
    }

    public void objectEnable() 
    {
        
        objectSoundEffect.SetActive(true);
    }
    public void objectDisable() 
    {
       
        objectSoundEffect.SetActive(false);
    }
}

