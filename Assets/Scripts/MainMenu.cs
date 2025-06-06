using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject selectLvlPanel;
    public GameObject mainMenuPanel;

    // settings
    public Slider masterVol, musicVol, sfxVol;

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

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        // play sfx
        PlayClickSFX();
        selectLvlPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void PlayClickSFX()
    {
        AudioManager.instance.PlaySFXClip(clickSFX, transform);
    }
}
