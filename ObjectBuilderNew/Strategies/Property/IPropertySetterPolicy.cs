// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a policy for <see cref="PropertySetterStrategy"/>. The properties are
	/// indexed by the name of the property.
	/// </summary>
	public interface IPropertySetterPolicy : IBuilderPolicy
	{
		/// <summary>
		/// The property values to be set.
		/// </summary>
		Dictionary<string, IPropertySetterInfo> Properties { get; }
	}
}
