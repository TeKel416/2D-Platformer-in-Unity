using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            LoadMasterVolume();
        }
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            LoadMusicVolume();
        }
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            LoadSFXVolume();
        }
    }

    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVol", masterVol.value);
        PlayerPrefs.SetFloat("MasterVol", masterVol.value);
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVol", musicVol.value);
        PlayerPrefs.SetFloat("MusicVol", musicVol.value);
    }

    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVol", sfxVol.value);
        PlayerPrefs.SetFloat("SFXVol", sfxVol.value);
    }

    public void LoadMasterVolume()
    {
        masterVol.value = PlayerPrefs.GetFloat("MasterVol");
        ChangeMasterVolume();
    }

    public void LoadMusicVolume()
    {
        musicVol.value = PlayerPrefs.GetFloat("MusicVol");
        ChangeMusicVolume();
    }

    public void LoadSFXVolume()
    {
        sfxVol.value = PlayerPrefs.GetFloat("SFXVol");
        ChangeSFXVolume();
    }
}
