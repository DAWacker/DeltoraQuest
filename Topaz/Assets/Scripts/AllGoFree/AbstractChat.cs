using UnityEngine;
using System;
using System.Collections;
using System.Text;

namespace Assets.Scripts.AllGoFree
{
	public abstract class AbstractChat : DialogueStep {

		/// <summary>
		/// The text for the chat.
		/// </summary>
		protected readonly object[] text;

		/// <summary>
		/// Creates a new AbstractChat.
		/// </summary>
		/// <param name="text">The text for the chat.</param>
		public AbstractChat(params object[] text)
		{
			this.text = text;
		}

		/// <summary>
		/// Execute the step.
		/// </summary>
		/// <param name="session">The session.</param>
		public abstract void execute(DialogueSession session);

		/// <summary>
		/// Get the text to display.
		/// </summary>
		/// <returns>The text.</returns>
		/// <param name="session">The session.</param>
		protected string[] getText(DialogueSession session)
		{
			string[] renderedText = new string[text.Length];
			for (int i = 0; i < renderedText.Length; i++)
			{
				renderedText[i] = text[i].ToString();
			}
			return renderedText;
		}

		/// <summary>
		/// Decode message data from a byte array.
		/// </summary>
		/// <returns>The decoded message data.</returns>
		/// <param name="data">The byte array.</param>
		public static object[] decodeFromBytes(byte[] data)
		{
			Packet p = new Packet(data);
			string[] strings = p.readString().Split('\n');
			object[] objects = new object[strings.Length];
			for (int i = 0; i < strings.Length; i++)
			{
				objects[i] = (String)strings[i];
			}
			return objects;
		}

	}
}