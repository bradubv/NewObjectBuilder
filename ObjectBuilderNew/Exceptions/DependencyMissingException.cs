// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Runtime.Serialization;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Indicates that a dependency could not be resolved.
	/// </summary>
	[Serializable]
	public class DependencyMissingException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyMissingException"/> class.
		/// </summary>
		public DependencyMissingException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyMissingException"/> class
		/// using the provided message.
		/// </summary>
		/// <param name="message">Error Message</param>
		public DependencyMissingException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyMissingException"/> class
		/// using the provided message and inner exception.
		/// </summary>
		/// <param name="message">Error Message</param>
		/// <param name="exception">Inner Exception</param>
		public DependencyMissingException(string message, Exception exception)
			: base(message, exception)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyMissingException"/> class
		/// using the provided deserialization information.
		/// </summary>
		protected DependencyMissingException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
