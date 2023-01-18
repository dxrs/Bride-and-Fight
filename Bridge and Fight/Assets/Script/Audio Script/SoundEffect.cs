using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static SoundEffect soundEffect;

    public AudioSource[] audioSources;

    [SerializeField] int soundValueData;
}
