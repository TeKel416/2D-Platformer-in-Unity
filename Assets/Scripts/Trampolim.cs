using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public float bounce = 35f;
    public float bounceDuration = 0.25f;
    private Animator anim;
    public AudioClip trampolimSFX;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Push(transform.up * bounce, bounceDuration);

            anim.SetTrigger("jumped");

            // play sfx
            AudioManager.instance.PlayRandomPitchSFXClip(trampolimSFX, transform);
        }
    }
}