//===============================================================================
// Ripped off from:
// Microsoft patterns & practices
// ObjectBuilder Application Block
//===============================================================================

using System;
using NUnit.Framework;

namespace cnt.ObjectBuilderNew
{
	[TestFixture]
	public class BuilderBaseFixture
	{
		[Test]
		public void AddingStrategyByAnyStageRunsItDuringBuild()
		{
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>();
			Locator locator = CreateLocator();

			MockStrategy strategy = new MockStrategy();
			builder.Strategies.Add(strategy, BuilderStage.PreCreation);

			builder.BuildUp<object>(locator, null, null);

			Assert.IsTrue(strategy.BuildWasRun);
		}

		[Test]
		public void StrategyStagesRunInProperOrder()
		{
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>();
			Locator locator = CreateLocator();

			MockStrategy strategy = new MockStrategy();

			builder.Strategies.Add(new MockStrategy("Creation "), BuilderStage.Creation);
			builder.Strategies.Add(new MockStrategy("PostInitialization "), BuilderStage.PostInitialization);
			builder.Strategies.Add(new MockStrategy("PreCreation "), BuilderStage.PreCreation);
			builder.Strategies.Add(new MockStrategy("Initialization "), BuilderStage.Initialization);

			string s = builder.BuildUp<string>(locator, null, null);

			Assert.AreEqual("PreCreation Creation Initialization PostInitialization ", s);
		}

		[Test]
		public void UnbuildStrategiesRunInOppositeOrderOfBuild()
		{
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>();
			Locator locator = CreateLocator();

			MockStrategy strategy = new MockStrategy();

			builder.Strategies.Add(new MockStrategy("Creation "), BuilderStage.Creation);
			builder.Strategies.Add(new MockStrategy("PostInitialization "), BuilderStage.PostInitialization);
			builder.Strategies.Add(new MockStrategy("PreCreation "), BuilderStage.PreCreation);
			builder.Strategies.Add(new MockStrategy("Initialization "), BuilderStage.Initialization);

			string s = builder.TearDown(locator, "");

			Assert.AreEqual("PostInitialization Initialization Creation PreCreation ", s);
		}

		[Test]
		//[ExpectedException(typeof(ArgumentNullException))]
		public void CannotUnbuildANullReference()
		{
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>();
			Locator locator = CreateLocator();

			Assert.Throws<ArgumentNullException>(
				() => { builder.TearDown(locator, (object)null); }
			);
		}

		[Test]
		////[ExpectedException(typeof(InvalidOperationException))]
		public void RunningABuilderBaseWithNoStrategiesThrows()
		{
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>();
			Locator locator = CreateLocator();

			Assert.Throws<InvalidOperationException>(
				() => { builder.BuildUp<object>(locator, null, null); }
			);
		}

		[Test]
		public void CanInitializeBuilderBaseWithConfigurator()
		{
			MockConfigurator config = new MockConfigurator();
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>(config);
			Assert.IsTrue(config.WasCalled);
		}

		[Test]
		public void BuildUpWithNoLocatorDoesNotThrow()
		{
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>();
			Locator locator = null;
			MockStrategy strategy = new MockStrategy();
			builder.Strategies.Add(strategy, BuilderStage.PreCreation);
			builder.BuildUp<object>(locator, null, null);
		}

		[Test]
		public void TearDownWithNoLocatorDoesNotThrow()
		{
			IBuilder<BuilderStage> builder = new BuilderBase<BuilderStage>();
			Locator locator = null;

			MockStrategy strategy = new MockStrategy();
			builder.Strategies.Add(strategy, BuilderStage.PreCreation);

			builder.TearDown<object>(locator, "");
		}

		#region Helpers

		private Locator CreateLocator()
		{
			Locator locator = new Locator();
			LifetimeContainer lifetime = new LifetimeContainer();
			locator.Add(typeof(ILifetimeContainer), lifetime);
			return locator;
		}

		class MockConfigurator : IBuilderConfigurator<BuilderStage>
		{
			public bool WasCalled = false;

			public void ApplyConfiguration(IBuilder<BuilderStage> builder)
			{
				WasCalled = true;
			}
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

		#endregion
	}
}
