// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Implementation of <see cref="ITypeMappingPolicy"/> which does simple type/ID
	/// mapping.
	/// </summary>
	public class TypeMappingPolicy : ITypeMappingPolicy
	{
		private DependencyResolutionLocatorKey pair;

		/// <summary>
		/// Initializes a new instance of the <see cref="TypeMappingPolicy"/> class using
		/// the provided type and ID.
		/// </summary>
		/// <param name="type">The new type to be returned during Map.</param>
		/// <param name="id">The new ID to be returned during Map.</param>
		public TypeMappingPolicy(Type type, string id)
		{
			pair = new DependencyResolutionLocatorKey(type, id);
		}

		/// <summary>
		/// See <see cref="ITypeMappingPolicy.Map"/> for more information.
		/// </summary>
		public DependencyResolutionLocatorKey Map(DependencyResolutionLocatorKey incomingTypeIDPair)
		{
			return pair;
		}
	}
}
