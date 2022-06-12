// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a policy for <see cref="SingletonStrategy"/>.
	/// </summary>
	public interface ISingletonPolicy : IBuilderPolicy
	{
		/// <summary>
		/// Returns true if the object should be a singleton.
		/// </summary>
		bool IsSingleton { get; }
	}
}
