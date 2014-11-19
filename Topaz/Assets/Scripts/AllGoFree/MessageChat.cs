using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class MessageChat : AbstractChat {

		/// <summary>
		/// The type of the step in RRD files.
		/// </summary>
		public const int RRD_TYPE = 2;

		/// <summary>
		/// Creates a new MessageChat.
		/// </summary>
		/// <param name="text">The text for the chat.</param>
		public MessageChat(params object[] text) : base(text)
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
		public static MessageChat create(byte[] data)
		{
			return new MessageChat(AbstractChat.decodeFromBytes(data));
		}

	}
}