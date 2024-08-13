using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioMixer audioMixer;


    // Start is called before the first frame update
    void Start()
    {
        audioMixer.GetFloat("SFXVolume", out float currentSFXVolume);
        audioMixer.GetFloat("MusicVolume", out float currentMusicVolume);
        sfxSlider.value = Mathf.Pow(10, (currentSFXVolume / 20));
        musicSlider.value = Mathf.Pow(10, currentMusicVolume / 20);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSFXSliderChange(float _sfxVolume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(_sfxVolume) * 20);
    }

    public void OnMusicSliderChange(float _musicVolume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(_musicVolume) * 20);
    }
}
