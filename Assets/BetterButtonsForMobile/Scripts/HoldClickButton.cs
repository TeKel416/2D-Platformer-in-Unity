using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/Hold Click Button")]
public class HoldClickButton : Button
{
    public UnityEvent onHoldClick;

    private bool isPointerDown;

    public override void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        ResetClick();
    }

    private void ResetClick()
    {
        isPointerDown = false;
    }

    private void Update()
    {
        if (isPointerDown)
        {
            if (onHoldClick != null)
                onHoldClick.Invoke();
        }
    }

    protected override void OnDisable()
    {
        ResetClick();
        base.OnDisable();
    }
}
