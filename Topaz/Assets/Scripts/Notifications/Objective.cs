using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Notifications
{
	public class Objective : MonoBehaviour, IObjective
	{
        Type collectionItemType;
        public Type CollectionItemType
        {
            get { return collectionItemType; }
            set { collectionItemType = value; }
        }

        public virtual void DisplayObjective()
        {
            throw new NotImplementedException("Must be implemented in child class");
        }

        public virtual void MoveToPosition(float x, float y, float z)
        {
            throw new NotImplementedException("Must be implemented in child class");
        }

        public virtual void HandleProgression()
        {
            throw new NotImplementedException("Must be implemented in child class");
        }
    }
}
