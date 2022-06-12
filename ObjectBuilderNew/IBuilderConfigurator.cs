// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

namespace Cnt.ObjectBuilder
{
	/// <summary>
	/// Represents an object that can configure a builder.
	/// </summary>
	/// <typeparam name="TStageEnum">The builder's stage enumeration</typeparam>
	public interface IBuilderConfigurator<TStageEnum>
	{
		/// <summary>
		/// Applies the configuration to the builder.
		/// </summary>
		/// <param name="builder">The builder to apply the configuration to.</param>
		void ApplyConfiguration(IBuilder<TStageEnum> builder);
	}
}