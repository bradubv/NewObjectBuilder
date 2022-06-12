// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Reflection;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Simple default creation policy which selects the first public constructor
	/// of an object, using the builder to resolve/create any parameters the
	/// constructor requires.
	/// </summary>
	public class DefaultCreationPolicy : ICreationPolicy
	{
		/// <summary>
		/// See <see cref="ICreationPolicy.SelectConstructor"/> for more information.
		/// </summary>
		public ConstructorInfo SelectConstructor(IBuilderContext context, Type typeToBuild, string idToBuild)
		{
			ConstructorInfo[] constructors = typeToBuild.GetConstructors();

			if (constructors.Length > 0)
				return constructors[0];

			return null;
		}

		/// <summary>
		/// See <see cref="ICreationPolicy.GetParameters"/> for more information.
		/// </summary>
		public object[] GetParameters(IBuilderContext context, Type type, string id, ConstructorInfo constructor)
		{
			ParameterInfo[] parms = constructor.GetParameters();
			object[] parmsValueArray = new object[parms.Length];

			for (int i = 0; i < parms.Length; ++i)
				parmsValueArray[i] = context.HeadOfChain.BuildUp(context, parms[i].ParameterType, null, id);

			return parmsValueArray;
		}
	}
}
