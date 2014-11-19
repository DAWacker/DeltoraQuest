using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class Mark : DialogueStep
	{

		/// <summary>
		/// The type of the step in RRD files.
		/// </summary>
		public const int RRD_TYPE = 5;

		/// <summary>
		/// The name of the mark.
		/// </summary>
		private readonly string name;

		/// <summary>
		/// Creates a new Mark.
		/// </summary>
		/// <param name="name">The name of the mark.</param>
		public Mark(string name)
		{
			this.name = name;
		}

		/// <summary>
		/// Get the name of the mark.
		/// </summary>
		/// <returns>The name.</returns>
		public string getName()
		{
			return name;
		}

		/// <summary>
		/// Execute the step.
		/// </summary>
		/// <param name="session">The session.</param>
		public virtual void execute(DialogueSession session)
		{
			throw new UnityException("Marks should not be in dialogue chains!");
		}

		/// <summary>
		/// Create an object from bytes.
		/// </summary>
		/// <param name="data">The bytes.</param>
		/// <returns>The object.</returns>
		public static Mark create(byte[] data)
		{
			Packet p = new Packet(data);
			return new Mark(p.readString());
		}
	}
}