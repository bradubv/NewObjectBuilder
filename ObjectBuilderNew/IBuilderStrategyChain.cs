// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System.Collections;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a chain of responsibility for builder strategies.
	/// </summary>
	public interface IBuilderStrategyChain
	{
		/// <summary>
		/// Retrieves the head of the chain.
		/// </summary>
		IBuilderStrategy Head { get; }

		/// <summary>
		/// Adds a strategy to the chain.
		/// </summary>
		/// <param name="strategy">The strategy to add to the chain.</param>
		void Add(IBuilderStrategy strategy);

		/// <summary>
		/// Adds strategies to the chain.
		/// </summary>
		/// <param name="strategies">The strategies to add to the chain.</param>
		void AddRange(IEnumerable strategies);

		/// <summary>
		/// Gets the next strategy in the chain, relative to the given strategy.
		/// </summary>
		/// <param name="currentStrategy">The current strategy.</param>
		/// <returns>The next strategy in the chain; returns null if the current
		/// strategy is the last in the chain.</returns>
		IBuilderStrategy GetNext(IBuilderStrategy currentStrategy);
	}
}