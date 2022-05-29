//===============================================================================
// Ripped off from:
// Microsoft patterns & practices
// ObjectBuilder Application Block
//===============================================================================

namespace cnt.ObjectBuilderNew
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