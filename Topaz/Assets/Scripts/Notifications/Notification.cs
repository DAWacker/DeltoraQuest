using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using UnityEngine;

public class Notification : MonoBehaviour
{
    float duration;

    TweenAlpha alphaTween;
    UILabel label;

	void Start ()
    {
        alphaTween = GetComponentInChildren<TweenAlpha>();
        label = GetComponentInChildren<UILabel>();
	}

    public void SetText(string text)
    {
        label.text = text;
    }

    public void DisplayNotification()
    {
        alphaTween.ResetToBeginning();
        alphaTween.PlayForward();
    }
}