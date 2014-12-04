using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class DialogueLoader {

		/// <summary>
		/// Parse a byte array into a DialogueChain.
		/// </summary>
		/// <param name="bytes">The byte array.</param>
		/// <returns>The DialogueChain.</returns>
		public DialogueChain parse(byte[] bytes)
		{
			// Create a new chain
			DialogueChain chain = new DialogueChain();

			// Load the data into a packet
			Packet p = new Packet(bytes);
			int count = p.readUnsignedWord();

			// Loop and load each step
			for (int i = 0; i < count; i++)
			{
				int type = p.readUnsignedWord();
				byte[] data = p.readByteArray();

				DialogueStep step = loadStep(type, data);
				if (step is Mark)
				{
					chain.mark(((Mark) step).getName());
				}
				else
				{
					chain.add(step);
				}
			}

			// Finalize and return the loaded chain
			chain.finalizeChain();
			return chain;
		}

		/// <summary>
		/// Load a DialogueStep from a byte array.
		/// </summary>
		/// <returns>The step.</returns>
		/// <param name="type">The type of step to load.</param>
		/// <param name="data">The data.</param>
		private DialogueStep loadStep(int type, byte[] data)
		{
			switch (type)
			{
			default:
				throw new UnityException("Unknown data type: " + type);
				break;
			case NpcChat.RRD_TYPE:
				return NpcChat.create(data);
			case PlayerChat.RRD_TYPE:
				return PlayerChat.create(data);
			case MessageChat.RRD_TYPE:
				return MessageChat.create(data);
			case Mark.RRD_TYPE:
				return Mark.create(data);
			case ChatTerminator.RRD_TYPE:
				return new ChatTerminator();
			case CheckQuestStatus.RRD_TYPE:
				return CheckQuestStatus.create(data);
			}
		}
	}
}