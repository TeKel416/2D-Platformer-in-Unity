using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Transform posA;
    public float speed = 3;
    Vector3 targetPos;
    bool fall = false;

    // SFX
    public AudioClip fallingSFX;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (fall)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }

        if (!fall) { 
        #if !UNITY_ANDROID
                Invoke("Fall", 0.15f);
        #else
                Invoke("Fall", 0.2f);
        #endif
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

    private void Fall()
    {
        // play sfx
        AudioManager.instance.PlaySFXClip(fallingSFX, transform);
        fall = true;
    }
}
