using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Notifications
{
    public class CounterObjective : Objective
    {
        int currentAmount;
        int targetAmount;

        Vector3 startPosition;
        string displayText;

        // Text labels
        UILabel textLabel;
        UILabel counterLabel;

        // Scale tweens
        TweenScale scaleTween;
        TweenScale counterScaleTweenIn;
        TweenScale counterScaleTweenOut;

        // Alpha tweens
        IEnumerable<TweenAlpha> alphaTweens;

        // Position tweens
        TweenPosition positionTween;

        public event Action OnObjectiveComplete;
        public event Action OnObjectiveDestroyed;

        public void Init(int targetAmount, string displayText)
        {
            // Grab the labels
            var labels = GetComponentsInChildren<UILabel>();
            textLabel = labels.Single(l => l.name.Equals("textLabel"));
            counterLabel = labels.Single(l => l.name.Equals("counterLabel"));

            // Grab the scale tweens
            var scaleTweens = GetComponentsInChildren<TweenScale>();
            scaleTween = scaleTweens.Single(t => t.tweenGroup == 0);
            counterScaleTweenIn = scaleTweens.Single(t => t.tweenGroup == 1);
            counterScaleTweenOut = scaleTweens.Single(t => t.tweenGroup == 2);
            counterScaleTweenOut.AddOnFinished(() =>
            {
                counterScaleTweenIn.ResetToBeginning();
                counterScaleTweenIn.PlayForward();
            });

            // Grab the alpha tween
            alphaTweens = GetComponentsInChildren<TweenAlpha>();
            alphaTweens.First().AddOnFinished(() =>
            {
                if (OnObjectiveDestroyed != null)
                    OnObjectiveDestroyed();
            });

            // Grab the position tween
            positionTween = GetComponentInChildren<TweenPosition>();

            currentAmount = 0;
            this.targetAmount = targetAmount;
            this.displayText = displayText;
            startPosition = transform.localPosition;
        }

        void UpdateCounterText()
        {
            counterLabel.text = "( " + currentAmount + "/" + targetAmount + " )";
        }

        public override void DisplayObjective()
        {
            textLabel.text = displayText;
            UpdateCounterText();

            scaleTween.ResetToBeginning();
            scaleTween.from = new Vector3(0.0f, 0.0f, 0.0f);
            scaleTween.to = new Vector3(1.0f, 1.0f, 1.0f);
            scaleTween.PlayForward();
        }

        public override void MoveToPosition(float x, float y, float z)
        {
            // Set and play the position tween
            positionTween.ResetToBeginning();
            positionTween.from = startPosition;
            positionTween.to = new Vector3(x, y, z);
            positionTween.PlayForward();
            positionTween.AddOnFinished(() => startPosition = new Vector3(x, y, z));
        }

        public void ScaleDown()
        {
            // Play the scale tween
            scaleTween.ResetToBeginning();
            scaleTween.from = new Vector3(1.0f, 1.0f, 1.0f);
            scaleTween.to = new Vector3(0.5f, 0.5f, 0.5f);
            scaleTween.PlayForward();
        }

        public void IncrementAmount()
        {
            if (currentAmount + 1 > targetAmount)
                return;

            currentAmount++;
            UpdateCounterText();

            counterScaleTweenOut.ResetToBeginning();
            counterScaleTweenOut.PlayForward();

            if (currentAmount == targetAmount)
            {
                if (OnObjectiveComplete != null)
                    OnObjectiveComplete();
                foreach (var tween in alphaTweens)
                {
                    tween.ResetToBeginning();
                    tween.PlayForward();
                }
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                IncrementAmount();
            }
        }
    }
}