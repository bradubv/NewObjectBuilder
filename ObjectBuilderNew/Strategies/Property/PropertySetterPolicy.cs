// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Implementation of <see cref="IPropertySetterPolicy"/>.
	/// </summary>
	public class PropertySetterPolicy : IPropertySetterPolicy
	{
		private Dictionary<string, IPropertySetterInfo> properties = new Dictionary<string, IPropertySetterInfo>();

		/// <summary>
		/// See <see cref="IPropertySetterPolicy.Properties"/> for more information.
		/// </summary>
		public Dictionary<string, IPropertySetterInfo> Properties
		{
			get { return properties; }
		}
	}
}
