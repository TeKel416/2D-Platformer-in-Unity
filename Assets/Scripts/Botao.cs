using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public Animator portaAnimator;
    public BoxCollider2D portaCollider;
    private Animator btnAnimator;
    private List<GameObject> buttonObjects = new List<GameObject>();

    // SFX
    public AudioClip portaAbrindoSFX;
    public AudioClip portaFechandoSFX;

    private void Start()
    {
        btnAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (buttonObjects.Contains(collision.gameObject))
        {
            return;
        }
        else
        {
            if (!btnAnimator.GetBool("isPressed"))
            {
                // play sfx
                AudioManager.instance.PlaySFXClip(portaAbrindoSFX, transform);
            }

            portaAnimator.SetBool("isOpen", true);
            btnAnimator.SetBool("isPressed", true);
            portaCollider.enabled = false;

            buttonObjects.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buttonObjects.Remove(collision.gameObject);

        if (buttonObjects.Count == 0)
        {
            portaAnimator.SetBool("isOpen", false);
            btnAnimator.SetBool("isPressed", false);
            portaCollider.enabled = true;

            // play sfx
            AudioManager.instance.PlaySFXClip(portaFechandoSFX, transform);
        }
    }
}
