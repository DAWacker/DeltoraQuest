using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Items;
using Assets.Scripts.Notifications;

namespace Assets.Scripts.Player
{
    public class PlayerInfo : MonoBehaviour
    {
        List<Objective> objectives;
        Inventory inventory;

        void Start()
        {
            objectives = new List<Objective>();
        }

        public void AddNewObjective(Objective objective)
        {
            objectives.Add(objective);
        }

        public void RemoveObjective(Objective objective)
        {
            if (objectives.Contains(objective))
                objectives.Remove(objective);
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Collectable"))
            {
                var collectable = col.gameObject.GetComponent<Collectable>();
                foreach (var objective in objectives)
                {
                    if (objective.CollectionItemType == collectable.Type)
                    {
                        Destroy(collectable.gameObject);
                        objective.HandleProgression();
                    }
                }
            }
        }
    }
}