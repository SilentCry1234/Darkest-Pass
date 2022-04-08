using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;
    [Space]
    public AudioSource backgroundMusic, hit, EnemyShoot, PlayerDeath, EnemyDeath, potion, hitPlayer, fireStone;

    public static AudioManager instance;

    [Range(-80f, 20f)]
    public float masterVol, effectsVol;
    public Slider masterSlider, effectsSlider; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
            instance = this; 
        }
    }

    private void Start()
    {
        PlayAudio(backgroundMusic);
        masterSlider.value = masterVol;
        effectsSlider.value = effectsVol;

        masterSlider.minValue = -80f;
        masterSlider.maxValue = 10f;

        effectsSlider.minValue = -80f;
        effectsSlider.maxValue = 10f;
    }

    void Update()
    {
        MasterVolume();
        EffectsVolume(); 
    }

    public void MasterVolume()
    {
        musicMixer.SetFloat("Master Volume", masterSlider.value);
    }
    public void EffectsVolume()
    {
        effectsMixer.SetFloat("Effects Volume", effectsSlider.value);
    }
    public void PlayAudio (AudioSource audio)
    {
        audio.Play(); 
    }
}
