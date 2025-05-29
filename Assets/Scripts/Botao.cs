using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    public Animator portaAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        portaAnimator.SetBool("isOpen", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        portaAnimator.SetBool("isOpen", false);
    }
}
