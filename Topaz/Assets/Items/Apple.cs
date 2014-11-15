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
        }

        public override void Collect()
        {
        }
	}
}
