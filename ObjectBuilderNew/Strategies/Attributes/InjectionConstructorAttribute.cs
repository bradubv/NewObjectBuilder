// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Attribute to specify which constructor on an object will be used for dependency injection.
	/// </summary>
	[AttributeUsage(AttributeTargets.Constructor)]
	public class InjectionConstructorAttribute : Attribute
	{
	}
}
