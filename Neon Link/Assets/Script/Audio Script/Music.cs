using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music music;

    public AudioSource audioSource;

    public string id; //-> membedakan music di scene in game, select level, level, level boss

    [SerializeField] int musicValueData;
    [SerializeField] GameObject objectMusic;

    private void Awake()
    {
        music = this;
    }

    private void Start()
    {
        musicValueData = PlayerPrefs.GetInt(SaveDataManager.saveDataManager.listDataName[10]);
        if (musicValueData == 1)
        {
            audioSource.enabled = true;

        }
        if (musicValueData == 0)
        {
            audioSource.enabled = false;

        }
    }

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        
    }

    public void objectEnable()
    {
        audioSource.enabled = true;

    }
    public void objectDisable()
    {
        audioSource.enabled = false;

    }
}
