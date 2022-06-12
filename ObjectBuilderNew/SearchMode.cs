// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.
namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Indicates the search mode to be used for locator queries
	/// </summary>
	public enum SearchMode
	{
		/// <summary>
		/// Search local first and then up the containment heirarchy as needed
		/// </summary>
		Up,

		/// <summary>
		/// Search local only
		/// </summary>
		Local
	}
}