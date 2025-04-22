using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] string tagFilter;
    [SerializeField] UnityEvent onTriggerEnter2D;
    [SerializeField] bool destroyOnTriggerEnter2D;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // verifica se o que entrou na area de colisao possui uma tag especifica
        if (!string.IsNullOrEmpty(tagFilter) && !collision.gameObject.CompareTag(tagFilter)) return;

        onTriggerEnter2D.Invoke();

        // destroi a colisao apos o trigger ter sido acionado
        if (destroyOnTriggerEnter2D)
        {
            Destroy(gameObject);
        }
    }
}
