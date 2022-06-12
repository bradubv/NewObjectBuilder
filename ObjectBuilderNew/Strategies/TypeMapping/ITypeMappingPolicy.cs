// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a policy for <see cref="TypeMappingStrategy"/>.
	/// </summary>
	public interface ITypeMappingPolicy : IBuilderPolicy
	{
		/// <summary>
		/// Maps one Type/ID pair to another.
		/// </summary>
		/// <param name="incomingTypeIDPair">The incoming Type/ID pair.</param>
		/// <returns>The new Type/ID pair.</returns>
		DependencyResolutionLocatorKey Map(DependencyResolutionLocatorKey incomingTypeIDPair);
	}
}
