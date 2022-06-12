// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a policy for <see cref="MethodExecutionStrategy"/>.
	/// </summary>
	public interface IMethodPolicy : IBuilderPolicy
	{
		/// <summary>
		/// A collection of methods to be called on the object instance.
		/// </summary>
		Dictionary<string, IMethodCallInfo> Methods { get; }
	}
}
