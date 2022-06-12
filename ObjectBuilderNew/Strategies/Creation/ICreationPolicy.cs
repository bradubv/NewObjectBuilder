// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Reflection;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a policy for <see cref="CreationStrategy"/>.
	/// </summary>
	public interface ICreationPolicy : IBuilderPolicy
	{
		/// <summary>
		/// Selects the constructor to be used to create the object.
		/// </summary>
		/// <param name="context">The builder context.</param>
		/// <param name="type">The type of object requested.</param>
		/// <param name="id">The ID of the object requested.</param>
		/// <returns>The constructor to use; returns null if no suitable constructor can be found.</returns>
		ConstructorInfo SelectConstructor(IBuilderContext context, Type type, string id);

		/// <summary>
		/// Gets the parameter values to be passed to the constructor.
		/// </summary>
		/// <param name="context">The builder context.</param>
		/// <param name="type">The type of object requested.</param>
		/// <param name="id">The ID of the object requested.</param>
		/// <param name="constructor">The constructor that will be used.</param>
		/// <returns>An array of parameters to pass to the constructor.</returns>
		object[] GetParameters(IBuilderContext context, Type type, string id, ConstructorInfo constructor);
	}
}
