// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// A abstract implementation of <see cref="IReadWriteLocator"/>.
	/// </summary>
	public abstract class ReadWriteLocator : ReadableLocator, IReadWriteLocator
	{
		/// <summary>
		/// See <see cref="IReadableLocator.ReadOnly"/> for more information.
		/// </summary>
		public override bool ReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// See <see cref="IReadWriteLocator.Add(object, object)"/> for more information.
		/// </summary>
		public abstract void Add(object key, object value);

		/// <summary>
		/// See <see cref="IReadWriteLocator.Remove(object)"/> for more information.
		/// </summary>
		public abstract bool Remove(object key);
	}
}