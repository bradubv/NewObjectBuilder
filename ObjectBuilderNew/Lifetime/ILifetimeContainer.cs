// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a lifetime container.
	/// </summary>
	/// <remarks>
	/// A lifetime container tracks the lifetime of an object, and implements
	/// IDisposable. When the container is disposed, any objects in the
	/// container which implement IDisposable are also disposed.
	/// </remarks>
	public interface ILifetimeContainer : IEnumerable<object>, IDisposable
	{
		/// <summary>
		/// Returns the number of references in the lifetime container
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Adds an object to the lifetime container.
		/// </summary>
		/// <param name="item">The item to be added.</param>
		void Add(object item);

		/// <summary>
		/// Determine if a given object is in the lifetime container.
		/// </summary>
		/// <param name="item">The item to test.</param>
		/// <returns>Returns true if the object is contained in the lifetime
		/// container; returns false otherwise.</returns>
		bool Contains(object item);

		/// <summary>
		/// Removes an item from the lifetime container. The item is
		/// not disposed.
		/// </summary>
		/// <param name="item">The item to be removed.</param>
		void Remove(object item);
	}
}