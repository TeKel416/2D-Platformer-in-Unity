using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUI : MonoBehaviour
{
    public GameObject mobileUI;

#if !UNITY_ANDROID
    void Awake()
    {
        mobileUI.SetActive(false);
    }
#endif
}
