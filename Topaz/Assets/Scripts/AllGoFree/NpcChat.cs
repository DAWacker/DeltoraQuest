using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class NpcChat : AbstractChat {

		/// <summary>
		/// The type of the step in RRD files.
		/// </summary>
		public const int RRD_TYPE = 0;

		/// <summary>
		/// Creates a new NpcChat.
		/// </summary>
		/// <param name="text">The text for the chat.</param>
		public NpcChat(params object[] text) : base(text)
		{
			
		}

		/// <summary>
		/// Execute the step.
		/// </summary>
		/// <param name="session">The session.</param>
		public override void execute(DialogueSession session)
		{
			
		}

		/// <summary>
		/// Create an object from bytes.
		/// </summary>
		/// <param name="data">The bytes.</param>
		/// <returns>The object.</returns>
		public static NpcChat create(byte[] data)
		{
			return new NpcChat(AbstractChat.decodeFromBytes(data));
		}
		
	}
}