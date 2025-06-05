using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AudioSettings;

#if UNITY_ANDROID
public class MobileUI : MonoBehaviour
{
    public GameObject mobileUI;
    public GameObject webUI;


    void Awake()
    {
        mobileUI.SetActive(true);

        if (webUI != null)
        {
            webUI.SetActive(false);
        }
    }
}

#else
    public class MobileUI : MonoBehaviour
    {
        public GameObject mobileUI;
        public GameObject webUI;


        void Awake()
        {
            mobileUI.SetActive(false);

            if (webUI != null)
            {
                webUI.SetActive(true);
            }
        }
    }
#endif