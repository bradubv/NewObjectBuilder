// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Implementation of <see cref="IBuilderStrategy"/> which remaps type and ID.
	/// </summary>
	/// <remarks>
	/// This strategy looks for policies in the context registered under the interface type
	/// <see cref="ITypeMappingPolicy"/>. The purpose of this strategy is to allow a user to
	/// ask for some generic type (say, "the IDatabase with an ID of 'sales'") and have it
	/// mapped into the appropriate concrete type (say, "an instance of SalesDatabase").
	/// </remarks>
	public class TypeMappingStrategy : BuilderStrategy
	{
		/// <summary>
		/// Implementation of <see cref="IBuilderStrategy.BuildUp"/>.
		/// </summary>
		public override object BuildUp(IBuilderContext context, Type t, object existing, string id)
		{
			DependencyResolutionLocatorKey result = new DependencyResolutionLocatorKey(t, id);
			ITypeMappingPolicy policy = context.Policies.Get<ITypeMappingPolicy>(t, id);

			if (policy != null)
			{
				result = policy.Map(result);
				TraceBuildUp(context, t, id, Properties.Resources.TypeMapped, result.Type, result.ID ?? "(null)");
				Guard.TypeIsAssignableFromType(t, result.Type, t);
			}

			return base.BuildUp(context, result.Type, existing, result.ID);
		}
	}
}
