﻿// Copyright © 2022 cntsoftware.com
// Contains software or other content adapted from Microsoft patterns & practices ObjectBuilder,
// © 2006 Microsoft Corporation. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Cnt.ObjectBuilder
{
	[TestFixture]
	public class BuilderFixture
	{
		[Test]
		public void EmptyBuilderWillCreateAnyValueTypeWithDefaultValue()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();

			int actual = builder.BuildUp<int>(locator, null, null);
			Assert.AreEqual(default(int), actual);
		}

		[Test]
		public void EmptyBuilderWillCreateSimpleInstances()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();

			SimpleObject o = builder.BuildUp<SimpleObject>(locator, null, null);

			Assert.IsNotNull(o);
			Assert.AreEqual(0, o.IntParam);
		}

		[Test]
		public void EmptyBuilderWillCreateComplexInstances()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();

			ComplexObject o = builder.BuildUp<ComplexObject>(locator, null, null);

			Assert.IsNotNull(o);
			Assert.IsNotNull(o.SimpleObject);
			Assert.AreEqual(default(int), o.SimpleObject.IntParam);
		}

		[Test]
		public void CanAddPoliciesToBuilder()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();

			ConstructorPolicy policy = new ConstructorPolicy();
			policy.AddParameter(new ValueParameter<int>(12));
			builder.Policies.Set<ICreationPolicy>(policy, typeof(MockObject), null);

			MockObject obj = builder.BuildUp<MockObject>(locator, null, null);

			Assert.IsNotNull(obj);
			Assert.AreEqual(12, obj.IntValue);
		}

		[Test]
		public void CanAddPoliciesToBuilderForTypeAndID()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();
			ConstructorPolicy policy = new ConstructorPolicy();
			policy.AddParameter(new ValueParameter<int>(14));
			builder.Policies.Set<ICreationPolicy>(policy, typeof(MockObject), "foo");

			MockObject obj = builder.BuildUp<MockObject>(locator, "foo", null);

			Assert.IsNotNull(obj);
			Assert.AreEqual(14, obj.IntValue);
		}

		[Test]
		public void CanCreateSingletonObjectWithDefaultObjectBuilder()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();

			builder.Policies.Set<ISingletonPolicy>(new SingletonPolicy(true), typeof(MockObject), "foo");

			MockObject obj1 = builder.BuildUp<MockObject>(locator, "foo", null);
			MockObject obj2 = builder.BuildUp<MockObject>(locator, "foo", null);

			Assert.AreSame(obj1, obj2);
		}

		[Test]
		public void CanMapTypesWithDefaultObjectBuilder()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();

			TypeMappingPolicy policy = new TypeMappingPolicy(typeof(MockObject), null);
			builder.Policies.Set<ITypeMappingPolicy>(policy, typeof(IMockObject), null);

			IMockObject obj = builder.BuildUp<IMockObject>(locator, null, null);

			Assert.IsTrue(obj is MockObject);
		}

		[Test]
		public void CanCreateObjectWithPropertyInjectionWithDefaultObjectBuilder()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();

			PropertySetterPolicy policy = new PropertySetterPolicy();
			policy.Properties.Add("IntProp", new PropertySetterInfo("IntProp", new ValueParameter<int>(64)));
			builder.Policies.Set<IPropertySetterPolicy>(policy, typeof(PropertyObject), null);

			PropertyObject obj = builder.BuildUp<PropertyObject>(locator, null, null);

			Assert.AreEqual(64, obj.IntProp);
		}

		[Test]
		public void BuilderCanTakeTransientPolicies()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();
			PolicyList policies = new PolicyList();

			PropertySetterPolicy policy = new PropertySetterPolicy();
			policy.Properties.Add("IntProp", new PropertySetterInfo("IntProp", new ValueParameter<int>(96)));
			policies.Set<IPropertySetterPolicy>(policy, typeof(PropertyObject), null);

			PropertyObject obj = builder.BuildUp<PropertyObject>(locator, null, null, policies);

			Assert.AreEqual(96, obj.IntProp);
		}

		[Test]
		public void TransientPoliciesOverrideBuilderPolicies()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();
			PolicyList policies = new PolicyList();

			PropertySetterPolicy builderPolicy = new PropertySetterPolicy();
			builderPolicy.Properties.Add("IntProp", new PropertySetterInfo("IntProp", new ValueParameter<int>(11)));
			builder.Policies.Set<IPropertySetterPolicy>(builderPolicy, typeof(PropertyObject), null);

			PropertySetterPolicy transientPolicy = new PropertySetterPolicy();
			transientPolicy.Properties.Add("IntProp", new PropertySetterInfo("IntProp", new ValueParameter<int>(22)));
			policies.Set<IPropertySetterPolicy>(transientPolicy, typeof(PropertyObject), null);

			PropertyObject obj = builder.BuildUp<PropertyObject>(locator, null, null, policies);

			Assert.AreEqual(22, obj.IntProp);
		}

		[Test]
		public void SingletonPolicyBasedOnConcreteTypeRatherThanRequestedType()
		{
			Builder builder = new Builder();
			Locator locator = CreateLocator();
			builder.Policies.Set<ITypeMappingPolicy>(new TypeMappingPolicy(typeof(Foo), null), typeof(IFoo), null);
			builder.Policies.SetDefault<ISingletonPolicy>(new SingletonPolicy(true));

			object obj1 = builder.BuildUp(locator, typeof(IFoo), null, null);
			object obj2 = builder.BuildUp(locator, typeof(IFoo), null, null);

			Assert.AreSame(obj1, obj2);
		}

		#region Helpers

		interface IFoo { }

		class Foo : IFoo { }

		private Locator CreateLocator()
		{
			Locator locator = new Locator();
			LifetimeContainer lifetime = new LifetimeContainer();
			locator.Add(typeof(ILifetimeContainer), lifetime);
			return locator;
		}

		private class MockStrategy : BuilderStrategy
		{
			public string StringValue;
			public bool BuildWasRun = false;
			public bool UnbuildWasRun = false;

			public MockStrategy()
				: this("")
			{
			}

			public MockStrategy(string value)
			{
				StringValue = value;
			}

			public override object BuildUp(IBuilderContext context, Type t, object existing, string id)
			{
				BuildWasRun = true;
				return base.BuildUp(context, t, AppendString(existing), id);
			}

			public override object TearDown(IBuilderContext context, object item)
			{
				UnbuildWasRun = true;
				return base.TearDown(context, AppendString(item));
			}

			private string AppendString(object item)
			{
				string result;

				if (item == null)
					result = StringValue;
				else
					result = ((string)item) + StringValue;

				return result;
			}
		}

		private class MockLifetimeContainer : ILifetimeContainer
		{
			public bool WasDisposed = false;

			public void Add(object item)
			{
				throw new NotImplementedException();
			}

			public bool Contains(object item)
			{
				throw new NotImplementedException();
			}

			public void Dispose()
			{
				WasDisposed = true;
			}

			public void Remove(object item)
			{
				throw new NotImplementedException();
			}

			public IEnumerator<object> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			public int Count
			{
				get { throw new NotImplementedException(); }
			}

			public event EventHandler<LifetimeEventArgs> Added;
			public event EventHandler<LifetimeEventArgs> Removed;

			private void UnusedEventsWarningRemoval()
			{
				Added(null, null);
				Removed(null, null);
			}
		}

		private class MockLocator : ReadWriteLocator
		{
			public object AddedKey;
			public object AddedValue;

			public override int Count
			{
				get { throw new NotImplementedException(); }
			}

			public override void Add(object key, object value)
			{
				AddedKey = key;
				AddedValue = value;
			}

			public override bool Contains(object key, SearchMode options)
			{
				throw new NotImplementedException();
			}

			public override object Get(object key, SearchMode options)
			{
				throw new NotImplementedException();
			}

			public override IEnumerator<KeyValuePair<object, object>> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			public override bool Remove(object key)
			{
				throw new NotImplementedException();
			}
		}

		private class SimpleObject
		{
			public int IntParam;

			public SimpleObject(int foo)
			{
				IntParam = foo;
			}
		}

		private class PropertyObject
		{
			private int intProp;

			public int IntProp
			{
				get { return intProp; }
				set { intProp = value; }
			}

			public PropertyObject()
			{
			}
		}

		private class ComplexObject
		{
			public SimpleObject SimpleObject;

			public ComplexObject(SimpleObject monk)
			{
				SimpleObject = monk;
			}
		}

		private interface IMockObject
		{
		}

		private class MockObject : IMockObject
		{
			public int IntValue;

			public MockObject(int val)
			{
				IntValue = val;
			}
		}

		#endregion
	}
}
