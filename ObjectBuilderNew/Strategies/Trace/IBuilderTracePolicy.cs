// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
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
