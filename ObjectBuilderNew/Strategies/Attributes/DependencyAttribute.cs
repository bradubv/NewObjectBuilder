// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Attribute applied to properties and constructor parameters, to describe when the dependency
	/// injection system should inject an object.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public sealed class DependencyAttribute : ParameterAttribute
	{
		private string name;
		private Type createType;
		private NotPresentBehavior notPresentBehavior = NotPresentBehavior.CreateNew;
		private SearchMode searchMode;

		/// <summary>
		/// Initializes a new instance of the <see cref="DependencyAttribute"/> class.
		/// </summary>
		public DependencyAttribute()
		{
		}

		/// <summary>
		/// The name of the object to inject. Optional.
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		/// <summary>
		/// The type to be created, when <see cref="DependencyAttribute.NotPresentBehavior"/> is set
		/// to <see cref="NotPresentBehavior.CreateNew"/>
		/// and an existing object cannot be found. Optional.
		/// </summary>
		public Type CreateType
		{
			get { return createType; }
			set { createType = value; }
		}

		/// <summary>
		/// Specifies how the dependency will be searched in the locator.
		/// </summary>
		public SearchMode SearchMode
		{
			get { return searchMode; }
			set { searchMode = value; }
		}


		/// <summary>
		/// The behavior when the object isn't found. Defaults to 
		/// <see cref="NotPresentBehavior.CreateNew"/>.
		/// </summary>
		public NotPresentBehavior NotPresentBehavior
		{
			get { return notPresentBehavior; }
			set { notPresentBehavior = value; }
		}

		/// <summary>
		/// See <see cref="ParameterAttribute.CreateParameter"/> for more information.
		/// </summary>
		public override IParameter CreateParameter(Type annotatedMemberType)
		{
			return new DependencyParameter(annotatedMemberType, name, createType, notPresentBehavior, searchMode);
		}
	}
}
