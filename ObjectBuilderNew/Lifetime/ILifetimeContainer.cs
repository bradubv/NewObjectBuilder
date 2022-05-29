﻿//===============================================================================
// Ripped off from:
// Microsoft patterns & practices
// ObjectBuilder Application Block
//===============================================================================

using System;
using System.Collections.Generic;

namespace cnt.ObjectBuilderNew
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