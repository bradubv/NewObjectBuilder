// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Enumeration describing how to handle when a dependency is not present.
	/// </summary>
	public enum NotPresentBehavior
	{
		/// <summary>
		/// Create the object
		/// </summary>
		CreateNew,

		/// <summary>
		/// Return null
		/// </summary>
		ReturnNull,

		/// <summary>
		/// Throw a DependencyMissingException
		/// </summary>
		Throw,
	}
}
