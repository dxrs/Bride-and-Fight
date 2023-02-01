using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static SoundEffect soundEffect;

    public AudioSource[] audioSources;
    public AudioClip[] audioClips;

    public int soundValueData;

    [SerializeField] GameObject objectSoundEffect;

    private void Awake()
    {
        soundEffect = this;
    }

    private void Start()
    {
        soundValueData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[9]);
        if (soundValueData == 1)
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].mute = false;
            }
        }
        if (soundValueData == 0)
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].mute = true;
            }
        }
    }

   
    

    public void objectEnable() 
    {
        
        for(int i = 0; i < audioSources.Length; i++) 
        {
            audioSources[i].mute = false;
        }
    }
    public void objectDisable() 
    {

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].mute = true;
        }
    }
}

