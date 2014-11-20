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
        int size = 1;
        int stackAmount = 1;
        string imageName;

        public Type Type { get { return type; } set { type = value; } }
        public int Size { get { return size; } set { size = value; } }
        public int StackAmount { get { return stackAmount; } set { stackAmount = value; } }
        public string ImageName { get { return imageName; } set { imageName = value; } }

        public virtual void Collect()
        {
            throw new NotImplementedException("Must be implemented in child class");
        }
    }
}
