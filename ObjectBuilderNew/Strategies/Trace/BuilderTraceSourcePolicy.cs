// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System.Diagnostics;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// An implementation of <see cref="IBuilderTracePolicy"/> which logs the trace messages
	/// through a <see cref="TraceSource"/>.
	/// </summary>
	public class BuilderTraceSourcePolicy : IBuilderTracePolicy
	{
		TraceSource traceSource;

		/// <summary>
		/// Initializes a new instance of the <see cref="BuilderTraceSourcePolicy"/> class
		/// using the provided trace source.
		/// </summary>
		public BuilderTraceSourcePolicy(TraceSource traceSource)
		{
			this.traceSource = traceSource;
		}

		/// <summary>
		/// See <see cref="IBuilderTracePolicy.Trace"/> for more information.
		/// </summary>
		public void Trace(string format, params object[] args)
		{
			traceSource.TraceInformation(format, args);
		}
	}
}