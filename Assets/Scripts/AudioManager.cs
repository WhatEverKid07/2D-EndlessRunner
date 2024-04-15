using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio-------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip vendingMachineExplosion;
    public AudioClip coinCollection;
    public AudioClip mainMenuMusic;
    public AudioClip running;

    private void Start()
    {
        
    }
}