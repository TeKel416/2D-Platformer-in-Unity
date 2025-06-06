using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource SFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnLocation, float volume = 1f, float pitch = 1f)
    {
        // spawna um gameObject
        AudioSource audioSource = Instantiate(SFXObject, spawnLocation.position, Quaternion.identity);

        // coloca o audio a ser tocado
        audioSource.clip = audioClip;

        // seta o volume
        audioSource.volume = volume;

        // seta o pitch (opcional)
        audioSource.pitch = pitch;

        // toca o som
        audioSource.Play();

        // pega o tempo de duração do audio
        float clipLenght = audioSource.clip.length;

        // destroi o audio apos terminar
        Destroy(audioSource.gameObject, clipLenght);
    }

    public void PlayRandomPitchSFXClip(AudioClip audioClip, Transform spawnLocation, float volume = 1f)
    {
        // spawna um gameObject
        AudioSource audioSource = Instantiate(SFXObject, spawnLocation.position, Quaternion.identity);

        // coloca o audio a ser tocado
        audioSource.clip = audioClip;

        // seta o volume
        audioSource.volume = volume;

        // aleatoriza o pitch
        audioSource.pitch = Random.Range(1f, 1.5f);

        // toca o som
        audioSource.Play();

        // pega o tempo de duração do audio
        float clipLenght = audioSource.clip.length;

        // destroi o audio apos terminar
        Destroy(audioSource.gameObject, clipLenght);
    }
}
