﻿// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents a locator that can be read from and written to.
	/// </summary>
	/// <remarks>
	/// <para>A locator is dictionary of keys to values, but it keeps the values with
	/// weak references, so that locating an object does not keep it alive. If you
	/// want to keep the object alive too, you should consider using an
	/// <see cref="ILifetimeContainer"/>.</para>
	/// <para>Locators have a built-in concept of hierarchy, so you can ask questions
	/// of a locator and tell it whether to return results from the current locator
	/// only, or whether to ask the parent locator when local lookups fail.</para>
	/// </remarks>
	public interface IReadWriteLocator : IReadableLocator
	{
		/// <summary>
		/// Adds an object to the locator, with the given key.
		/// </summary>
		/// <param name="key">The key to register the object with.</param>
		/// <param name="value">The object to be registered.</param>
		/// <exception cref="ArgumentNullException">Key or value are null.</exception>
		void Add(object key, object value);

		/// <summary>
		/// Removes an object from the locator.
		/// </summary>
		/// <param name="key">The key under which the object was registered.</param>
		/// <returns>Returns true if the object was found in the locator; returns
		/// false otherwise.</returns>
		/// <exception cref="ArgumentNullException">Key is null.</exception>
		bool Remove(object key);
	}
}