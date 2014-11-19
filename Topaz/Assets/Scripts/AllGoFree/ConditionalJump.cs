using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public abstract class ConditionalJump : DialogueStep
	{
		/// <summary>
		/// The mark to jump to if the condition is met.
		/// </summary>
		private readonly string trueMark;

		/// <summary>
		/// The mark to jump to if the condition is not met.
		/// </summary>
		private readonly string falseMark;

		/// <summary>
		/// Creates a new ConditionalJump
		/// </summary>
		/// <param name="trueMark">The mark to jump to if the condition is met.</param>
		/// <param name="falseMark">The mark to jump to if the condition is not met.</param>
		public ConditionalJump(string trueMark, string falseMark)
		{
			this.trueMark = trueMark;
			this.falseMark = falseMark;
		}

		/// <summary>
		/// Check if the condition is met.
		/// </summary>
		/// <returns><c>true</c>, if condition met was met, <c>false</c> otherwise.</returns>
		/// <param name="session">The session.</param>
		public abstract bool isConditionMet(DialogueSession session);

		/// <summary>
		/// Get the name of the mark to jump to if the condition is met.
		/// </summary>
		/// <returns>The mark name.</returns>
		public string getTrueMark()
		{
			return trueMark;
		}

		/// <summary>
		/// Get the name of the mark to jump to if the condition is not met.
		/// </summary>
		/// <returns>The mark name.</returns>
		public string getFalseMark()
		{
			return falseMark;
		}

		/// <summary>
		/// Execute the step.
		/// </summary>
		/// <param name="session">The session.</param>
		public virtual void execute(DialogueSession session)
		{
			string mark = isConditionMet(session) ? getTrueMark() : getFalseMark();
			if (mark != null && !mark.Equals(""))
			{
				session.jumpToMark(mark);
			}
			else
			{
				session.jumpToIndex(session.getIndex()+1);
			}
			session.continueSession();
		}
	}
}