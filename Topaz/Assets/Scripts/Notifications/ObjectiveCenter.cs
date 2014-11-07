using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using UnityEngine;
using Assets.Items;
using Assets.Scripts.Player;

namespace Assets.Scripts.Notifications
{
    public class ObjectiveCenter : MonoBehaviour
    {
        float objectiveStartPosY = 240.0f;
        float objectiveStartPosX = 0.0f;

        float objectivePlacementY = 250.0f;
        float objectivePlacementX = -500.0f;

        float objectiveHeight = 40.0f;

        List<Objective> objectives = new List<Objective>();

        public GameObject player;
        public GameObject counterObjective;

        PlayerInfo playerInfo;

        void Start()
        {
            playerInfo = player.GetComponent<PlayerInfo>();
            StartCoroutine(WaitThenGiveObjective());
        }

        IEnumerator WaitThenGiveObjective()
        {
            var newCounterObjective = (GameObject)Instantiate(counterObjective);
            var objective = newCounterObjective.GetComponent<CounterObjective>();
            objective.transform.parent = transform.parent;
            objective.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            objective.transform.localPosition = new Vector3(
                objectiveStartPosX, 
                objectiveStartPosY, 
                0.0f);

            objective.Init(typeof(Apple), 5, "Collect 5 apples");
            objective.DisplayObjective();

            var objectiveDestoryed = Observable.FromEvent(
                a => objective.OnObjectiveDestroyed += a,
                a => objective.OnObjectiveDestroyed -= a).Take(1);
            objectiveDestoryed.Subscribe(destoryed =>
            {
                CleanUpObjective(newCounterObjective, objective);
            });

            yield return new WaitForSeconds(2f);
            objective.MoveToPosition(
                objectivePlacementX, 
                objectiveStartPosY - (objectives.Count * objectiveHeight), 
                0.0f);
            objective.ScaleDown();
            objectives.Add(objective);
            playerInfo.AddNewObjective(objective);
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

        void CleanUpObjective(GameObject visual, Objective objective)
        {
            objectives.Remove(objective);
            playerInfo.RemoveObjective(objective);
            DestroyImmediate(visual);
            UpdateObjectives();
        }
    }
}