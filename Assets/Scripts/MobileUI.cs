using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUI : MonoBehaviour
{
    public GameObject mobileUI;
    public GameObject webUI;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            mobileUI.SetActive(true);

            if (webUI != null)
            {
                webUI.SetActive(false);
            }
        }
        else
        {
            mobileUI.SetActive(false);
        }
    }
}
