// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Runtime.Serialization;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Indicates that a dependency could not be resolved because the resolved type is
	/// not compatible with the injected type.
	/// </summary>
	[Serializable]
	public class IncompatibleTypesException : Exception
	{
		/// <summary>
		/// Initializes the exception.
		/// </summary>
		public IncompatibleTypesException()
		{
		}

		/// <summary>
		/// Initializes the exception.
		/// </summary>
		/// <param name="message">Error Message</param>
		public IncompatibleTypesException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes the exception.
		/// </summary>
		/// <param name="message">Error Message</param>
		/// <param name="exception">Inner Exception</param>
		public IncompatibleTypesException(string message, Exception exception)
			: base(message, exception)
		{
		}

		/// <summary>
		/// Initializes the exception.
		/// </summary>
		protected IncompatibleTypesException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
