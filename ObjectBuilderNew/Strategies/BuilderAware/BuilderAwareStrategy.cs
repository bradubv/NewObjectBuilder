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
	/// Implementation of <see cref="IBuilderStrategy"/> which will notify an object about
	/// the completion of a <see cref="IBuilder{T}.BuildUp"/> operation, or start of a
	/// <see cref="IBuilder{T}.TearDown"/> operation.
	/// </summary>
	/// <remarks>
	/// This strategy checks the object that is passing through the builder chain to see if it
	/// implements IBuilderAware and if it does, it will call <see cref="IBuilderAware.OnBuiltUp"/>
	/// and <see cref="IBuilderAware.OnTearingDown"/>. This strategy is meant to be used from the
	/// <see cref="BuilderStage.PostInitialization"/> stage.
	/// </remarks>
	public class BuilderAwareStrategy : BuilderStrategy
	{
		/// <summary>
		/// See <see cref="IBuilderStrategy.BuildUp"/> for more information.
		/// </summary>
		public override object BuildUp(IBuilderContext context, Type t, object existing, string id)
		{
			IBuilderAware awareObject = existing as IBuilderAware;

			if (awareObject != null)
			{
				TraceBuildUp(context, t, id, Properties.Resources.CallingOnBuiltUp);
				awareObject.OnBuiltUp(id);
			}

			return base.BuildUp(context, t, existing, id);
		}

		/// <summary>
		/// See <see cref="IBuilderStrategy.TearDown"/> for more information.
		/// </summary>
		public override object TearDown(IBuilderContext context, object item)
		{
			IBuilderAware awareObject = item as IBuilderAware;

			if (awareObject != null)
			{
				TraceTearDown(context, item, Properties.Resources.CallingOnTearingDown);
				awareObject.OnTearingDown();
			}

			return base.TearDown(context, item);
		}
	}
}
