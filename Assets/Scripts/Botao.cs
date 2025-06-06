using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public Animator portaAnimator;
    public BoxCollider2D portaCollider;
    private Animator btnAnimator;
    private List<GameObject> buttonObjects = new List<GameObject>();
    public AudioClip botaoSFX;
    public AudioClip portaSFX;

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
            portaAnimator.SetBool("isOpen", true);
            btnAnimator.SetBool("isPressed", true);
            portaCollider.enabled = false;

            buttonObjects.Add(collision.gameObject);

            // play sfx
            AudioManager.instance.PlaySFXClip(botaoSFX, transform);
            AudioManager.instance.PlaySFXClip(portaSFX, transform);
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
            AudioManager.instance.PlaySFXClip(portaSFX, transform, 1f, -1f);
        }
    }
}
