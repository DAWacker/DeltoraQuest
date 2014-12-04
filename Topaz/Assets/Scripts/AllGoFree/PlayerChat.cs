using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class PlayerChat : AbstractChat {

		/// <summary>
		/// The type of the step in RRD files.
		/// </summary>
		public const int RRD_TYPE = 1;

		/// <summary>
		/// Creates a new PlayerChat.
		/// </summary>
		/// <param name="text">The text for the chat.</param>
		public PlayerChat(params object[] text) : base(text)
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
		public static PlayerChat create(byte[] data)
		{
			return new PlayerChat(AbstractChat.decodeFromBytes(data));
		}
		
	}
}