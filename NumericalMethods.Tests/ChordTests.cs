using System;
using NumericalMethods.Core;
using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class ChordTests
	{
		private readonly Func<double, double> _function = x => Math.Sin(x) + 2 * Math.Pow(x, 2) - 5;
		private readonly double _accuracy = 0.0001;
		
		[Test]
		public void ProcessWithIntervalOnNegativeAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(-5, 0);
			var chord = new Chord(_function, _accuracy, interval);

			//act
			var root = chord.Process();
			TestContext.Out.WriteLine($"{chord.IterationCounter} iterated");

			//assert
			Assert.IsTrue(root.EqualWithTolerance(-1.7302, _accuracy));
		}
		
		[Test]
		public void ProcessWithIntervalOnPositiveAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(0, 5);
			var chord = new Chord(_function, _accuracy, interval);
			
			//act
			var root = chord.Process();	
			TestContext.Out.WriteLine($"{chord.IterationCounter} iterated");
			
			//assert
			Assert.IsTrue(root.EqualWithTolerance(1.4163, _accuracy));
		}

		[Test]
		public void ProcessWithIntervalWithoutRoot_ShouldThrowException()
		{
			//arrange
			var interval = new Interval(10, 20);
			var chord = new Chord(_function, _accuracy, interval);
			
			//act
			var exception = Assert.Throws<Exception>(() => chord.Process());
			TestContext.Out.WriteLine(exception?.Message);

			//assert
			Assert.NotNull(exception);
		}
	}
}