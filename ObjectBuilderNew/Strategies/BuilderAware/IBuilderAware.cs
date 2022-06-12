// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Implemented on a class when it wants to receive notifications
	/// about the build process.
	/// </summary>
	public interface IBuilderAware
	{
		/// <summary>
		/// Called by the <see cref="BuilderAwareStrategy"/> when the object is being built up.
		/// </summary>
		/// <param name="id">The ID of the object that was just built up.</param>
		void OnBuiltUp(string id);

		/// <summary>
		/// Called by the <see cref="BuilderAwareStrategy"/> when the object is being torn down.
		/// </summary>
		void OnTearingDown();
	}
}
