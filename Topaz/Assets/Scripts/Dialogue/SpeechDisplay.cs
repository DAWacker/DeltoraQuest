using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using UnityEngine;

public class SpeechDisplay : MonoBehaviour
{
    TweenScale scale;
    UILabel textDisplayBox;

    string textToDisplay;

    float timeBetweenLetters;
    float elapsedTime;

    bool displayText = false;

    int stringIndex;

    Vector3 scaleStart;
    Vector3 scaleEnd;

    void Start()
    {
        scale = GetComponent<TweenScale>();
        scaleStart = scale.from;
        scaleEnd = scale.to;

        textDisplayBox = GetComponentInChildren<UILabel>();
        StartCoroutine(WaitThenDisplay());
    }

    IEnumerator WaitThenDisplay()
    {
        yield return new WaitForSeconds(2f);
        DisplayBubble();
        yield return new WaitForSeconds(.5f);
        DisplayText("I am testing this string to see if it will print out in 3 seconds.", 0.5f);
    }

    IEnumerator WaitThenHide()
    {
        yield return new WaitForSeconds(2f);
        HideBubble();
    }

    void DisplayBubble()
    {
        scale.ResetToBeginning();
        scale.to = scaleEnd;
        scale.from = scaleStart;
        scale.PlayForward();
    }

    void HideBubble()
    {
        scale.ResetToBeginning();
        scale.to = scaleStart;
        scale.from = scaleEnd;
        scale.PlayForward();
    }

    public void DisplayText(string text, float duration)
    {
        textToDisplay = text;

        timeBetweenLetters = duration / text.Length;
        elapsedTime = 0.0f;
        stringIndex = 0;

        displayText = true;
    }

    void Update()
    {
        if (displayText)
        {
            if (elapsedTime >= timeBetweenLetters)
            {
                var lettersToDisplay = (float)(elapsedTime / timeBetweenLetters);
                var wholeLetters = (int)Math.Floor(lettersToDisplay);
                var remainder = elapsedTime - (wholeLetters * timeBetweenLetters);

                if (stringIndex + wholeLetters > textToDisplay.Length)
                    wholeLetters = textToDisplay.Length - stringIndex;

                for (int i = stringIndex; i < stringIndex + wholeLetters; i++)
                    textDisplayBox.text += textToDisplay[i];

                stringIndex += wholeLetters;
                elapsedTime = remainder;

                if (stringIndex >= textToDisplay.Length)
                {
                    displayText = false;
                    StartCoroutine(WaitThenHide());
                    return;
                }
            }
            elapsedTime += Time.deltaTime;
        }
    }
}