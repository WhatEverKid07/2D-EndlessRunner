using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider allSound;
    public Slider musicSlider;
    public Slider SFX_Slider;

    public static float allAudioSliderVolumeStatic;
    public static float musicSliderVolumeStatic;
    public static float SFX_SliderVolumeStatic;

    [Header("Starting Value")]
    public  float allAudioSliderVolume;
    public  float musicSliderVolume;
    public  float SFX_SliderVolume;
    [Space]
    [Space]

    public AudioMixer musicMixer;

    public bool isGameScene;

    private void Start()
    {
        if (!isGameScene)
        {
            allSound.value = allAudioSliderVolume;
            musicSlider.value = musicSliderVolume;
            SFX_Slider.value = SFX_SliderVolume;
        }
        else
        {
            musicMixer.SetFloat("MasterVolume",allSound.value);
            musicMixer.SetFloat("SFXVolume",SFX_Slider.value);
            musicMixer.SetFloat("MusicVolume",musicSlider.value);

            allSound.value = allAudioSliderVolumeStatic;
            musicSlider.value = musicSliderVolumeStatic;
            SFX_Slider.value = SFX_SliderVolumeStatic;
        }
    }


    private void Update()
    {
        musicMixer.SetFloat("MasterVolume", allSound.value);
        musicMixer.SetFloat("SFXVolume", SFX_Slider.value);
        musicMixer.SetFloat("MusicVolume", musicSlider.value);

        allAudioSliderVolumeStatic = allSound.value;
        musicSliderVolumeStatic = musicSlider.value;
        SFX_SliderVolumeStatic = SFX_Slider.value;

        allAudioSliderVolume = allAudioSliderVolumeStatic;
        musicSliderVolume = musicSliderVolumeStatic;
        SFX_SliderVolume = SFX_SliderVolumeStatic;

        if(musicSlider.value == -20)
        {
            musicMixer.SetFloat("MusicVolume", -80);
        }
        if (SFX_Slider.value == -20)
        {
            musicMixer.SetFloat("SFXVolume", -80);
        }
        if (allSound.value == -45)
        {
            musicMixer.SetFloat("MasterVolume", -80);
        }
    }
}