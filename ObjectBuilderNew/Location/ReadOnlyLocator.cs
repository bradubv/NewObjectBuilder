﻿// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// An implementation of <see cref="IReadableLocator"/> that wraps an existing locator
	/// to ensure items are not written into the locator.
	/// </summary>
	public class ReadOnlyLocator : ReadableLocator
	{
		private IReadableLocator innerLocator;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="innerLocator">The inner locator to be wrapped.</param>
		public ReadOnlyLocator(IReadableLocator innerLocator)
		{
			if (innerLocator == null)
				throw new ArgumentNullException("innerLocator");

			this.innerLocator = innerLocator;
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Count"/> for more information.
		/// </summary>
		public override int Count
		{
			get { return innerLocator.Count; }
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Count"/> for more information.
		/// </summary>
		public override IReadableLocator ParentLocator
		{
			get
			{
				return new ReadOnlyLocator(innerLocator.ParentLocator);
			}
		}

		/// <summary>
		/// See <see cref="IReadableLocator.ReadOnly"/> for more information.
		/// </summary>
		public override bool ReadOnly
		{
			get { return true; }
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Contains(object, SearchMode)"/> for more information.
		/// </summary>
		public override bool Contains(object key, SearchMode options)
		{
			return innerLocator.Contains(key, options);
		}

		/// <summary>
		/// See <see cref="IReadableLocator.Get(object, SearchMode)"/> for more information.
		/// </summary>
		public override object Get(object key, SearchMode options)
		{
			return innerLocator.Get(key, options);
		}

		/// <summary>
		/// See <see cref="IEnumerable{T}.GetEnumerator()"/> for more information.
		/// </summary>
		public override IEnumerator<KeyValuePair<object, object>> GetEnumerator()
		{
			return innerLocator.GetEnumerator();
		}
	}
}