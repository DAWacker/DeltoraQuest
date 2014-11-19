using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.AllGoFree
{
	public class DialogueChain
	{

		/// <summary>
		/// The steps in the DialogueChain.
		/// </summary>
		private List<DialogueStep> steps;

		/// <summary>
		/// The marks in the DialogueChain.
		/// </summary>
		private Dictionary<string, int> marks;

		/// <summary>
		/// Has the dialogue chain been finalized.
		/// </summary>
		private bool finalized;

		/// <summary>
		/// Creates a new DialogueChain.
		/// </summary>
		public DialogueChain()
		{
			steps = new List<DialogueStep>();
			marks = new Dictionary<string, int>();
		}

		/// <summary>
		/// Add a step the DialogueChain.
		/// </summary>
		/// <param name="step">The step to add.</param>
		public void add(DialogueStep step)
		{
			if (finalized)
			{
				throw new UnityException("Dialogue chain is finalized.");
			}
			steps.Add(step);
		}

		/// <summary>
		/// Mark the last added step.
		/// </summary>
		/// <param name="name">The name of the mark.</param>
		public void mark(string name)
		{
			if (finalized)
			{
				throw new UnityException("Dialogue chain is finalized.");
			}
			marks.Add(name, steps.Count-1);
		}

		/// <summary>
		/// Get the DialogueStep at the specified index, or null if it does not exist.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The step.</returns>
		public DialogueStep get(int index)
		{
			if (index < 0 || index > steps.Count)
			{
				return null;
			}
			return steps[index];
		}

		/// <summary>
		/// Get an index from a mark name.
		/// </summary>
		/// <returns>The index.</returns>
		/// <param name="mark">The name of the mark.</param>
		public int getIndexForMark(string mark)
		{
			return marks[mark];
		}

		/// <summary>
		/// Finalize the Dialogue Chain.
		/// </summary>
		public void finalizeChain()
		{
			if (finalized)
			{
				throw new UnityException("Dialogue chain is finalized.");
			}
			finalized = true;
		}

		/// <summary>
		/// Execute a dialogue step.
		/// </summary>
		/// <param name="index">The index of the step to execute.</param>
		/// <param name="session">The DialogueSession.</param>
		/// <returns>If the session can continue.</returns>
		public bool execute(int index, DialogueSession session)
		{
			// Check if the index is valid
			if (index < 0 || index > steps.Count)
			{
				// Stop the session
				return false;
			}

			// Grab the step
			DialogueStep step = steps[index];

			// Execute the step
			step.execute(session);

			// Make ChatTerminators stop the session
			if (step is ChatTerminator)
			{
				return false;
			}

			// Indicate that the session can continue
			return true;
		}
	}
}