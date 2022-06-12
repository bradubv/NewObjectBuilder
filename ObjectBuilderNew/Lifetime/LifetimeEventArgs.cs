// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// The event data sent for the events of <see cref="ILifetimeContainer"/>.
	/// </summary>
	public class LifetimeEventArgs : EventArgs
	{
		private object item;

		/// <summary>
		/// The item that the event it about.
		/// </summary>
		public object Item
		{
			get { return item; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LifetimeEventArgs"/> class using
		/// the provided item.
		/// </summary>
		/// <param name="item">The item.</param>
		public LifetimeEventArgs(object item)
		{
			this.item = item;
		}
	}
}
