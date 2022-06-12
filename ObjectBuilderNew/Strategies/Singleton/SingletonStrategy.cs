// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Implementation of <see cref="IBuilderStrategy"/> which allows objects to be
	/// singletons.
	/// </summary>
	/// <remarks>
	/// This strategy looks for policies in the context registered under the interface type
	/// <see cref="ISingletonPolicy"/>. It uses the locator in the build context to rememeber
	/// singleton objects, and the lifetime container contained in the locator to ensure they
	/// are not garbage collected. Upon the second request for an object, it will short-circuit
	/// the strategy chain and return the singleton instance (and will not re-inject the
	/// object).
	/// </remarks>
	public class SingletonStrategy : BuilderStrategy
	{
		/// <summary>
		/// Implementation of <see cref="IBuilderStrategy.BuildUp"/>.
		/// </summary>
		/// <param name="context">The build context.</param>
		/// <param name="typeToBuild">The type of the object being built.</param>
		/// <param name="existing">The existing instance of the object.</param>
		/// <param name="idToBuild">The ID of the object being built.</param>
		/// <returns>The built object.</returns>
		public override object BuildUp(IBuilderContext context, Type typeToBuild, object existing, string idToBuild)
		{
			DependencyResolutionLocatorKey key = new DependencyResolutionLocatorKey(typeToBuild, idToBuild);

			if (context.Locator != null && context.Locator.Contains(key, SearchMode.Local))
			{
				TraceBuildUp(context, typeToBuild, idToBuild, "");
				return context.Locator.Get(key);
			}

			return base.BuildUp(context, typeToBuild, existing, idToBuild);
		}
	}
}
