using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[AddComponentMenu("UI/Timed Click Button")]
public class TimedClickButton : Button
{
    public Image fillImage;

    public float requiredHoldTime;

    private float pointerDownTimer;

    private bool isPointerDown;

    public UnityEvent onClickTimeFinished;

    public override void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        ResetButton();
    }

    private void Update()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer > requiredHoldTime)
            {
                if (onClickTimeFinished != null)
                {
                    onClickTimeFinished.Invoke();
                }

                ResetButton();
            }
        }
        if (fillImage != null)
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }

    private void ResetButton()
    {
        isPointerDown = false;
        pointerDownTimer = 0;
    }

    protected override void OnDisable()
    {
        ResetButton();
        base.OnDisable();
    }
}
