using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class DialogueSession
	{
		/// <summary>
		/// The dialogue chain.
		/// </summary>
		private readonly DialogueChain chain;

		/// <summary>
		/// The current index of the session.
		/// </summary>
		private int currentIndex;

		/// <summary>
		/// The last index of the session.
		/// </summary>
		private int lastIndex;

		/// <summary>
		/// Creates a new DialogueSession.
		/// </summary>
		/// <param name="chain">The DialogueChain.</param>
		public DialogueSession(DialogueChain chain)
		{
			this.chain = chain;
		}

		/// <summary>
		/// Jump to the specified mark.
		/// </summary>
		/// <param name="mark">The name of the mark.</param>
		public void jumpToMark(string mark)
		{
			lastIndex = currentIndex;
			currentIndex = chain.getIndexForMark(mark);
		}

		/// <summary>
		/// Jump to the specified index.
		/// </summary>
		/// <param name="index">The index to jump to.</param>
		public void jumpToIndex(int index)
		{
			lastIndex = currentIndex;
			currentIndex = index;
		}

		/// <summary>
		/// Get the current index.
		/// </summary>
		/// <returns>The index.</returns>
		public int getIndex()
		{
			return currentIndex;
		}

		/// <summary>
		/// Continue the dialogue session.
		/// </summary>
		public void continueSession()
		{
			// Save the last index
			lastIndex = currentIndex;

			// Execute the step
			bool result = chain.execute(currentIndex, this);

			// Check if the session should stop
			if (!result)
			{
				// TODO: Any cleanup for ending a session
				return;
			}

			// Make sure the code didn't cause a jump
			if (lastIndex == currentIndex)
			{
				currentIndex++;
			}
		}
	}
}