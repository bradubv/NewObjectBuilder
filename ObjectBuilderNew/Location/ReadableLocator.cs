﻿// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// A abstract implementation of <see cref="IReadableLocator"/>.
	/// </summary>
	public abstract class ReadableLocator : IReadableLocator
	{
		private IReadableLocator parentLocator;

		/// <summary>
		/// See <see cref="IReadableLocator.Count"/> for more information.
		/// </summary>
		public abstract int Count { get; }

		/// <summary>
		/// See <see cref="IReadableLocator.ParentLocator"/> for more information.
		/// </summary>
		public virtual IReadableLocator ParentLocator
		{
			get { return parentLocator; }
		}

		/// <summary>
		/// See <see cref="IReadableLocator.ReadOnly"/> for more information.
		/// </summary>
		public abstract bool ReadOnly { get; }

		/// <summary>
		/// See <see cref="IReadableLocator.Contains(object)"/> for more information.
		/// </summary>
		public bool Contains(object key)
		{
			return Contains(key, SearchMode.Up);
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Contains(object, SearchMode)"/> for more information.
		/// </summary>
		public abstract bool Contains(object key, SearchMode options);

		/// <summary>
		/// See <see cref="IReadableLocator.FindBy(Predicate{KeyValuePair{object, object}})"/> for more information.
		/// </summary>
		public IReadableLocator FindBy(Predicate<KeyValuePair<object, object>> predicate)
		{
			return FindBy(SearchMode.Up, predicate);
		}

		/// <summary>
		/// See <see cref="IReadableLocator.FindBy(SearchMode, Predicate{KeyValuePair{object, object}})"/> for more information.
		/// </summary>
		public IReadableLocator FindBy(SearchMode options, Predicate<KeyValuePair<object, object>> predicate)
		{
			if (predicate == null)
				throw new ArgumentNullException("predicate");
			if (!Enum.IsDefined(typeof(SearchMode), options))
				throw new ArgumentException(Properties.Resources.InvalidEnumerationValue, "options");

			Locator results = new Locator();
			IReadableLocator currentLocator = this;

			while (currentLocator != null)
			{
				FindInLocator(predicate, results, currentLocator);
				currentLocator = options == SearchMode.Local ? null : currentLocator.ParentLocator;
			}

			return new ReadOnlyLocator(results);
		}

		private void FindInLocator(Predicate<KeyValuePair<object, object>> predicate, Locator results,
											IReadableLocator currentLocator)
		{
			foreach (KeyValuePair<object, object> kvp in currentLocator)
			{
				if (!results.Contains(kvp.Key) && predicate(kvp))
				{
					results.Add(kvp.Key, kvp.Value);
				}
			}
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Get{T}()"/> for more information.
		/// </summary>
		public TItem Get<TItem>()
		{
			return (TItem)Get(typeof(TItem));
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Get{T}(object)"/> for more information.
		/// </summary>
		public TItem Get<TItem>(object key)
		{
			return (TItem)Get(key);
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Get{T}(object, SearchMode)"/> for more information.
		/// </summary>
		public TItem Get<TItem>(object key, SearchMode options)
		{
			return (TItem)Get(key, options);
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Get(object)"/> for more information.
		/// </summary>
		public object Get(object key)
		{
			return Get(key, SearchMode.Up);
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Get(object, SearchMode)"/> for more information.
		/// </summary>
		public abstract object Get(object key, SearchMode options);

		/// <summary>
		/// See <see cref="IEnumerable{T}.GetEnumerator()"/> for more information.
		/// </summary>
		public abstract IEnumerator<KeyValuePair<object, object>> GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <summary>
		/// Sets the parent locator for this locator.
		/// </summary>
		/// <param name="parentLocator">A <see cref="IReadableLocator"/> reference.</param>
		protected void SetParentLocator(IReadableLocator parentLocator)
		{
			this.parentLocator = parentLocator;
		}
	}
}