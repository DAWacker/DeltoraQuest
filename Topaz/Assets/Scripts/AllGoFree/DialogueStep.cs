using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public interface DialogueStep
	{
		/// <summary>
		/// Execute the step.
		/// </summary>
		/// <param name="session">The session.</param>
		void execute(DialogueSession session);

	}
}