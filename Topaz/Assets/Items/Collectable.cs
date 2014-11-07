using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Items
{
	public class Collectable : MonoBehaviour, ICollectable
	{
        Type type;
        public Type CollectableType { get { return type; } set { type = value; } }

        public virtual void Collect()
        {
            throw new NotImplementedException("Must be implemented in child class");
        }
    }
}
