﻿// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// An implementation of <see cref="ILifetimeContainer"/>.
	/// </summary>
	public class LifetimeContainer : ILifetimeContainer
	{
		private List<object> items = new List<object>();

		/// <summary>
		/// See <see cref="ILifetimeContainer.Count"/> for more information.
		/// </summary>
		public int Count
		{
			get { return items.Count; }
		}

		/// <summary>
		/// See <see cref="ILifetimeContainer.Add(object)"/> for more information.
		/// </summary>
		public void Add(object item)
		{
			items.Add(item);
		}

		/// <summary>
		/// See <see cref="ILifetimeContainer.Contains(object)"/> for more information.
		/// </summary>
		public bool Contains(object item)
		{
			return items.Contains(item);
		}

		/// <summary>
		/// Disposes the container, and any objects contained in the container.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Disposes the objects in the container.
		/// </summary>
		/// <param name="disposing">True if called from Dispose(); false if called from
		/// a finalizer.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				List<object> itemsCopy = new List<object>(items);
				itemsCopy.Reverse();

				foreach (object o in itemsCopy)
				{
					IDisposable d = o as IDisposable;

					if (d != null)
						d.Dispose();
				}

				items.Clear();
			}
		}

		/// <summary>
		/// See <see cref="ILifetimeContainer.Remove(object)"/> for more information.
		/// </summary>
		public void Remove(object item)
		{
			if (!items.Contains(item))
				return;

			items.Remove(item);
		}

		/// <summary>
		/// Returns an enumerator over the objects in the container.
		/// </summary>
		/// <returns>An enumerator.</returns>
		public IEnumerator<object> GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}