using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Notifications
{
	interface IObjective
	{
        void DisplayObjective();
        void MoveToPosition(float x, float y, float z);
        void HandleProgression();
	}
}
