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
    }

    private void OnEnable()
    {
        if (musicValueData == 1)
        {
            objectMusic.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (musicValueData == 0)
        {
            objectMusic.SetActive(false);
        }
    }

    public void objectEnable()
    {
        objectMusic.SetActive(true);
    }
    public void objectDisable()
    {
        objectMusic.SetActive(false);
    }
}
