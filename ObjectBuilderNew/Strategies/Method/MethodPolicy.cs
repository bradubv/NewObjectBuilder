// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System.Collections.Generic;

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// An implementation of <see cref="IMethodPolicy"/>.
	/// </summary>
	public class MethodPolicy : IMethodPolicy
	{
		private Dictionary<string, IMethodCallInfo> methods = new Dictionary<string, IMethodCallInfo>();

		/// <summary>
		/// See <see cref="IMethodPolicy.Methods"/> for more information.
		/// </summary>
		public Dictionary<string, IMethodCallInfo> Methods
		{
			get { return methods; }
		}
	}
}
