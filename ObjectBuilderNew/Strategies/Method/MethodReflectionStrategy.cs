// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Strategy that describes method call via attributes.
	/// </summary>
	public class MethodReflectionStrategy : ReflectionStrategy<MethodInfo>
	{
		/// <summary>
		/// See <see cref="ReflectionStrategy{T}.GetMembers"/> for more information.
		/// </summary>
		protected override IEnumerable<IReflectionMemberInfo<MethodInfo>> GetMembers(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			foreach (MethodInfo method in typeToBuild.GetMethods())
				yield return new ReflectionMemberInfo<MethodInfo>(method);
		}

		/// <summary>
		/// See <see cref="ReflectionStrategy{T}.AddParametersToPolicy"/> for more information.
		/// </summary>
		protected override void AddParametersToPolicy(IBuilderContext context, Type typeToBuild, string idToBuild, IReflectionMemberInfo<MethodInfo> member, IEnumerable<IParameter> parameters)
		{
			MethodPolicy result = context.Policies.Get<IMethodPolicy>(typeToBuild, idToBuild) as MethodPolicy;

			if (result == null)
			{
				result = new MethodPolicy();
				context.Policies.Set<IMethodPolicy>(result, typeToBuild, idToBuild);
			}

			result.Methods.Add(member.Name, new MethodCallInfo(member.MemberInfo, parameters));
		}

		/// <summary>
		/// See <see cref="ReflectionStrategy{T}.MemberRequiresProcessing"/> for more information.
		/// </summary>
		protected override bool MemberRequiresProcessing(IReflectionMemberInfo<MethodInfo> member)
		{
			return (member.GetCustomAttributes(typeof(InjectionMethodAttribute), true).Length > 0);
		}
	}
}