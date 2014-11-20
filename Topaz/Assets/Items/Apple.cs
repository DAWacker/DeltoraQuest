using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Items
{
	public class Apple : Collectable
	{
        void Start()
        {
            Type = typeof(Apple);
            ImageName = "apple";
        }

        public override void Collect()
        {
        }
	}
}
