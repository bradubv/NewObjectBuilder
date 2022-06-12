// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Reflection;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Encapsulates a property setter.
	/// </summary>
	public interface IPropertySetterInfo
	{
		/// <summary>
		/// Gets the value to be set into the property.
		/// </summary>
		/// <param name="context">The build context.</param>
		/// <param name="type">The type being built.</param>
		/// <param name="id">The ID being built.</param>
		/// <param name="propInfo">The property being set.</param>
		/// <returns>The value to be set into the property.</returns>
		object GetValue(IBuilderContext context, Type type, string id, PropertyInfo propInfo);

		/// <summary>
		/// Gets the property to be set.
		/// </summary>
		/// <param name="context">The build context.</param>
		/// <param name="type">The type being built.</param>
		/// <param name="id">The ID being built.</param>
		/// <returns>The property to be set; if the property cannot be found, returns null.</returns>
		PropertyInfo SelectProperty(IBuilderContext context, Type type, string id);
	}
}
