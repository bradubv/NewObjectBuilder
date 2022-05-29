//===============================================================================
// Ripped off from:
// Microsoft patterns & practices
// ObjectBuilder Application Block
//===============================================================================

namespace cnt.ObjectBuilderNew
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