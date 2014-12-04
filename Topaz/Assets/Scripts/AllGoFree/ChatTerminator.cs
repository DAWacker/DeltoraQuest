using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class ChatTerminator : DialogueStep {

		/// <summary>
		/// The type of the step in RRD files.
		/// </summary>
		public const int RRD_TYPE = 6;

		/// <summary>
		/// Execute the step.
		/// </summary>
		/// <param name="session">The session.</param>
		public virtual void execute(DialogueSession session)
		{

		}
		
	}
}