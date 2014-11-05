using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using UnityEngine;

namespace Notifications
{
    public class ObjectiveCenter : MonoBehaviour
    {
        float objectiveStartPosY = 240.0f;
        float objectiveStartPosX = 0.0f;

        float objectivePlacementY = 250.0f;
        float objectivePlacementX = -500.0f;

        float objectiveHeight = 40.0f;

        List<Objective> objectives = new List<Objective>();

        public GameObject counterObjective;

        void Start()
        {
        }

        IEnumerator WaitThenGiveObjective()
        {
            yield return new WaitForSeconds(2.0f);

            var newCounterObjective = (GameObject)Instantiate(counterObjective);
            var objective = newCounterObjective.GetComponent<CounterObjective>();
            objective.transform.parent = transform.parent;
            objective.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            objective.transform.localPosition = new Vector3(
                objectiveStartPosX, 
                objectiveStartPosY, 
                0.0f);

            objective.Init(5, "Hit the 'N' key 5 times");
            objective.DisplayObjective();

            var objectiveDestoryed = Observable.FromEvent(
                a => objective.OnObjectiveDestroyed += a,
                a => objective.OnObjectiveDestroyed -= a).Take(1);
            objectiveDestoryed.Subscribe(destoryed =>
            {
                objectives.Remove(objective);
                DestroyImmediate(newCounterObjective);
                UpdateObjectives();
            });

            yield return new WaitForSeconds(2f);
            objective.MoveToPosition(
                objectivePlacementX, 
                objectiveStartPosY - (objectives.Count * objectiveHeight), 
                0.0f);
            objective.ScaleDown();
            objectives.Add(objective);
        }

        void UpdateObjectives()
        {
            for (int i = 0; i < objectives.Count; i++)
            {
                var obj = objectives[i];
                obj.MoveToPosition(
                    objectivePlacementX, 
                    objectivePlacementY - (i * objectiveHeight), 
                    0.0f);
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                StartCoroutine(WaitThenGiveObjective());
            }
        }
    }
}