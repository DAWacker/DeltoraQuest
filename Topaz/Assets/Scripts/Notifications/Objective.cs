using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Notifications
{
	public class Objective : MonoBehaviour, IObjective
	{
        public virtual void DisplayObjective()
        {
            throw new NotImplementedException("Must be overridden in child class");
        }

        public virtual void MoveToPosition(float x, float y, float z)
        {
            throw new NotImplementedException("Must be overridden in child class");
        }
    }
}
