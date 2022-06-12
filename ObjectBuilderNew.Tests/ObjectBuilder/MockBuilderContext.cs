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
	internal class MockBuilderContext : BuilderContext
	{
		public IReadWriteLocator InnerLocator;
		public BuilderStrategyChain InnerChain = new BuilderStrategyChain();
		public PolicyList InnerPolicies = new PolicyList();
		public LifetimeContainer lifetimeContainer = new LifetimeContainer();

		public MockBuilderContext()
			: this(new Locator())
		{
		}

		public MockBuilderContext(IReadWriteLocator locator)
		{
			InnerLocator = locator;
			SetLocator(InnerLocator);
			StrategyChain = InnerChain;
			SetPolicies(InnerPolicies);

			if (!Locator.Contains(typeof(ILifetimeContainer)))
				Locator.Add(typeof(ILifetimeContainer), lifetimeContainer);
		}
	}
}
