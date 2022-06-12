// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Globalization;
using System.Reflection;

namespace Cnt.ObjectBuilder
{
	//TODO: There might be better ways to do this in later version of C# / .NET
	internal static class Guard
	{
		public static void TypeIsAssignableFromType(Type assignee, Type providedType, Type classBeingBuilt)
		{
			if (!assignee.IsAssignableFrom(providedType))
				throw new IncompatibleTypesException(string.Format(CultureInfo.CurrentCulture,
					Properties.Resources.TypeNotCompatible, assignee, providedType, classBeingBuilt));
		}

		public static void ValidateMethodParameters(MethodBase methodInfo, object[] parameters, Type typeBeingBuilt)
		{
			ParameterInfo[] paramInfos = methodInfo.GetParameters();

			for (int i = 0; i < paramInfos.Length; i++)
				if (parameters[i] != null)
					Guard.TypeIsAssignableFromType(paramInfos[i].ParameterType, parameters[i].GetType(), typeBeingBuilt);
		}
	}
}
