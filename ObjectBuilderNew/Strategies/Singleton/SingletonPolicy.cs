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
	/// <summary>
	/// Implementation of <see cref="ISingletonPolicy"/>.
	/// </summary>
	public class SingletonPolicy : ISingletonPolicy
	{
		private bool isSingleton;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="isSingleton">Whether the object should be a singleton.</param>
		public SingletonPolicy(bool isSingleton)
		{
			this.isSingleton = isSingleton;
		}

		/// <summary>
		/// See <see cref="ISingletonPolicy.IsSingleton"/> for more information.
		/// </summary>
		public bool IsSingleton
		{
			get { return isSingleton; }
		}
	}
}
