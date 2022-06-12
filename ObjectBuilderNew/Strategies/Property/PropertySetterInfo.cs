// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Reflection;
namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Implementation of <see cref="IPropertySetterInfo"/> which can take either a property
	/// name or a <see cref="PropertyInfo"/> already gathered from reflection.
	/// </summary>
	public class PropertySetterInfo : IPropertySetterInfo
	{
		string name = null;
		PropertyInfo prop = null;
		IParameter value = null;

		/// <summary>
		/// Initializes a new instance of <see cref="PropertySetterInfo"/> using the provided
		/// property name and value.
		/// </summary>
		/// <param name="name">The name of the property to be set.</param>
		/// <param name="value">The value to be set into the property.</param>
		public PropertySetterInfo(string name, IParameter value)
		{
			this.name = name;
			this.value = value;
		}

		/// <summary>
		/// Instantiates a new instance of <see cref="PropertySetterInfo"/> using the provided
		/// <see cref="PropertyInfo"/> and value.
		/// </summary>
		/// <param name="propInfo">The property to be set.</param>
		/// <param name="value">The value to set into the property.</param>
		public PropertySetterInfo(PropertyInfo propInfo, IParameter value)
		{
			this.prop = propInfo;
			this.value = value;
		}

		/// <summary>
		/// See <see cref="IPropertySetterInfo.SelectProperty"/> for more information.
		/// </summary>
		public PropertyInfo SelectProperty(IBuilderContext context, Type type, string id)
		{
			if (prop != null)
				return prop;

			return type.GetProperty(name);
		}

		/// <summary>
		/// See <see cref="IPropertySetterInfo.GetValue"/> for more information.
		/// </summary>
		public object GetValue(IBuilderContext context, Type type, string id, PropertyInfo propInfo)
		{
			return value.GetValue(context);
		}
	}
}
