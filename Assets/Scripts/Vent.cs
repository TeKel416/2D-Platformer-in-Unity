using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        Debug.Log ("Colisão entrou na área");
    }
}
