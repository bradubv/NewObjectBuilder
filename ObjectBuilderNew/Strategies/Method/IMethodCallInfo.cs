// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Encapsulates a method call.
	/// </summary>
	public interface IMethodCallInfo
	{
		/// <summary>
		/// Gets the parameter values to be passed to the method.
		/// </summary>
		/// <param name="context">The builder context.</param>
		/// <param name="type">The type of object requested.</param>
		/// <param name="id">The ID of the object requested.</param>
		/// <param name="method">The method that will be used.</param>
		/// <returns>An array of parameters to pass to the method.</returns>
		object[] GetParameters(IBuilderContext context, Type type, string id, MethodInfo method);

		/// <summary>
		/// Selects the method to be called.
		/// </summary>
		/// <param name="context">The builder context.</param>
		/// <param name="type">The type of object requested.</param>
		/// <param name="id">The ID of the object requested.</param>
		/// <returns>The method to use; return null if no suitable method can be found.</returns>
		MethodInfo SelectMethod(IBuilderContext context, Type type, string id);
	}
}
