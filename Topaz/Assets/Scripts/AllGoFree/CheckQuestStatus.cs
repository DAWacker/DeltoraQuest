using UnityEngine;
using System.Collections;

namespace Assets.Scripts.AllGoFree
{
	public class CheckQuestStatus : ConditionalJump
	{

		/// <summary>
		/// The type of the step in RRD files.
		/// </summary>
		public const int RRD_TYPE = 13;

		/// <summary>
		/// The short name of the Quest.
		/// </summary>
		private readonly string questShortName;

		/// <summary>
		/// The short name of the node for the Quest.
		/// </summary>
		private readonly string nodeShortName;

		/// <summary>
		/// The minimum step required.
		/// </summary>
		private readonly string minimumStep;

		/// <summary>
		/// The maximum step required.
		/// </summary>
		private readonly string maximumStep;
		
		public CheckQuestStatus(
			string questShortName, 
			string nodeShortName, 
			string minimumStep, 
			string maximumStep, 
			string trueMark, 
			string falseMark
		) : base(trueMark, falseMark)
		{
			this.questShortName = questShortName;
			this.nodeShortName = nodeShortName;
			this.minimumStep = minimumStep;
			this.maximumStep = maximumStep;
		}

		/// <summary>
		/// Check if the condition is met.
		/// </summary>
		/// <returns><c>true</c>, if the condition was met, <c>false</c> otherwise.</returns>
		/// <param name="session">The session.</param>
		public override bool isConditionMet(DialogueSession session)
		{
			// TODO: Check the player's current status
			return false;
		}

		/// <summary>
		/// Create an object from bytes.
		/// </summary>
		/// <param name="data">The bytes.</param>
		/// <returns>The object.</returns>
		public static CheckQuestStatus create(byte[] data)
		{
			Packet p = new Packet(data);
			return new CheckQuestStatus(
				p.readString(), 
				p.readString(), 
				p.readString(), 
				p.readString(), 
				p.readString(), 
				p.readString()
				);
		}

	}
}