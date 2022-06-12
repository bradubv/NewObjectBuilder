// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a single parameter used for constructor and method calls, and
	/// property setting.
	/// </summary>
	public interface IParameter
	{
		/// <summary>
		/// Gets the type of the parameter value.
		/// </summary>
		/// <param name="context">The build context.</param>
		/// <returns>The parameter's type.</returns>
		Type GetParameterType(IBuilderContext context);

		/// <summary>
		/// Gets the parameter value.
		/// </summary>
		/// <param name="context">The build context.</param>
		/// <returns>The parameter's value.</returns>
		object GetValue(IBuilderContext context);
	}
}
