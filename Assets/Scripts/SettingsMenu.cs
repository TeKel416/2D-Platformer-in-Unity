using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainAudioMixer;

    // SFX
    public AudioClip clickSFX;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            masterVol.value = PlayerPrefs.GetFloat("MasterVol");
        }
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            musicVol.value = PlayerPrefs.GetFloat("MusicVol");
        }
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            sfxVol.value = PlayerPrefs.GetFloat("SFXVol");
        }
    }

    public void SetMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVol", Mathf.Log10(masterVol.value) * 20f);
        PlayerPrefs.SetFloat("MasterVol", masterVol.value);
    }

    public void SetMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVol", Mathf.Log10(musicVol.value) * 20f);
        PlayerPrefs.SetFloat("MusicVol", musicVol.value);
    }

    public void SetSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVol", Mathf.Log10(sfxVol.value) * 20f);
        PlayerPrefs.SetFloat("SFXVol", sfxVol.value);
    }

    public void PlayClickSFX()
    {
        AudioManager.instance.PlaySFXClip(clickSFX, transform);
    }
}
