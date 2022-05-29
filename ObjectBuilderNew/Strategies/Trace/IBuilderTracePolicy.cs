//===============================================================================
// Ripped off from:
// Microsoft patterns & practices
// ObjectBuilder Application Block
//===============================================================================

using System;

namespace cnt.ObjectBuilderNew
{
	/// <summary>
	/// Represents a tracing policy for ObjectBuilder.
	/// </summary>
	public interface IBuilderTracePolicy : IBuilderPolicy
	{
		/// <summary>
		/// Trace a message.
		/// </summary>
		/// <param name="format">Message format.</param>
		/// <param name="args">Message arguments.</param>
		void Trace(string format, params object[] args);
	}
}
