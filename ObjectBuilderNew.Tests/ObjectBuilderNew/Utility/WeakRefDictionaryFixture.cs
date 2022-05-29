//===============================================================================
// Ripped off from:
// Microsoft patterns & practices
// ObjectBuilder Application Block
//===============================================================================

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace cnt.ObjectBuilderNew
{
	[TestFixture]
	public class WeakRefDictionaryFixture
	{
		[Test]
		public void CanRegisterObjectAndFindItByID()
		{
			object o = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo", o);
			Assert.IsNotNull(dict["foo"]);
			Assert.AreSame(o, dict["foo"]);
		}

		[Test]
		public void CanRegisterTwoObjectsAndGetThemBoth()
		{
			object o1 = new object();
			object o2 = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo1", o1);
			dict.Add("foo2", o2);

			Assert.AreSame(o1, dict["foo1"]);
			Assert.AreSame(o2, dict["foo2"]);
		}

		[Test]
		public void KeyCanBeOfArbitraryType()
		{
			object oKey = new object();
			object oVal = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add(oKey, oVal);

			Assert.AreSame(oVal, dict[oKey]);
		}

		[Test]
		public void CanAddSameObjectTwiceWithDifferentKeys()
		{
			object o = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo1", o);
			dict.Add("foo2", o);

			Assert.AreSame(dict["foo1"], dict["foo2"]);
		}

		[Test]
		public void AskingForAKeyThatDoesntExistThrows()
		{
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();
			Assert.Throws<KeyNotFoundException>(
				() => { object unused = dict["foo"]; }
			);
			
		}

		[Test]
		public void CanRemoveAnObjectThatWasAlreadyAdded()
		{
			object o = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo", o);
			dict.Remove("foo");
			Assert.Throws<KeyNotFoundException>(
				() => { object unused = dict["foo"]; }
			);
		}

		[Test]
		public void RemovingAKeyOfOneObjectDoesNotAffectOtherKeysForSameObject()
		{
			object o = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo1", o);
			dict.Add("foo2", o);
			dict.Remove("foo1");

			Assert.AreSame(o, dict["foo2"]);
		}

		[Test]
		public void RemovingAKeyDoesNotAffectOtherKeys()
		{
			object o1 = new object();
			object o2 = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo1", o1);
			dict.Add("foo2", o2);
			dict.Remove("foo1");

			Assert.AreSame(o2, dict["foo2"]);
		}

		[Test]
		public void RemovingANonExistantKeyDoesntThrow()
		{
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();
			dict.Remove("foo1");
		}

		[Test]
		public void AddingToSameKeyTwiceAlwaysThrows()
		{
			object o = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo1", o);
			Assert.Throws<ArgumentException>(
				() => { dict.Add("foo1", o); }
			);
		}

		[Test]
		public void RegistrationDoesNotPreventGarbageCollection()
		{
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();
			AddEntry(dict);
			GC.Collect(); 
			Assert.Throws<KeyNotFoundException>(
				() => { object unused = dict["foo"]; }
			);
		}

		[Test]
		public void NullIsAValidValue()
		{
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();
			dict.Add("foo", null);
			Assert.IsNull(dict["foo"]);  //TODO: It is NullObject[Object,Object] instead of null
		}

		[Test]
		public void CanFindOutIfContainsAKey()
		{
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo", null);
			Assert.IsTrue(dict.ContainsKey("foo"));
			Assert.IsFalse(dict.ContainsKey("foo2"));
		}

		[Test]
		public void CanEnumerate()
		{
			object o1 = new object();
			object o2 = new object();
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			dict.Add("foo1", o1);
			dict.Add("foo2", o2);

			foreach (KeyValuePair<object, object> kvp in dict)
			{
				Assert.IsNotNull(kvp);
				Assert.IsNotNull(kvp.Key);
				Assert.IsNotNull(kvp.Value);
			}
		}

		[Test]
		public void CountReturnsNumberOfKeysWithLiveValues()
		{
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();

			Add2Entries(dict);
			Assert.AreEqual(2, dict.Count);

			GC.Collect();

			Assert.AreEqual(0, dict.Count);
		}

		[Test]
		public void CanAddItemAfterPreviousItemIsCollected()
		{
			WeakRefDictionary<object, object> dict = new WeakRefDictionary<object, object>();
			AddEntry(dict);

			GC.Collect();

			AddEntry(dict);
		}

		private void AddEntry(WeakRefDictionary<object, object> dict)
        {
			dict.Add("foo", new object());
        }

		private void Add2Entries(WeakRefDictionary<object, object> dict)
		{
			object o = new object();
			dict.Add("foo1", o);
			dict.Add("foo2", o);
		}
	}
}
