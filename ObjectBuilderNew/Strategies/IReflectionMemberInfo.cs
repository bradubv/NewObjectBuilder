// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Reflection;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Interface used by the <see cref="ReflectionStrategy{T}"/> base class to encapsulate the information
	/// required from members that use the strategy. This interface is required because direct access to
	/// the <see cref="MemberInfo"/> object may not give the desired results.
	/// </summary>
	public interface IReflectionMemberInfo<TMemberInfo>
	{
		/// <summary>
		/// Gets the original member info object.
		/// </summary>
		TMemberInfo MemberInfo { get; }

		/// <summary>
		/// Gets the name of the member.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the custom attributes of the member.
		/// </summary>
		/// <returns></returns>
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		/// <summary>
		/// Gets the parameters to be passed to the member.
		/// </summary>
		/// <returns></returns>
		ParameterInfo[] GetParameters();
	}
}
