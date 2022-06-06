using System;
using NUnit.Framework;
using NumericalMethods.Core;
using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;

namespace NumericalMethods.Tests
{
	public class DichotomyTests
	{
		private readonly Func<double, double> _function = x => Math.Sin(x) + 2 * Math.Pow(x, 2) - 5;
		private readonly double _accuracy = 0.0001;
		
		[Test]
		public void ProcessWithIntervalOnNegativeAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(-5, 0);
			var dichotomy = new Dichotomy(_function, interval, _accuracy);
			
			//act
			var solve = dichotomy.Process();	
			TestContext.Out.WriteLine($"{dichotomy.IterationCounter} iterated");
			
			//asssert
			Assert.IsTrue(solve.EqualWithTolerance(-1.7302, _accuracy));
		}

		[Test]
		public void ProcessWithIntervalOnPositiveAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(0, 5);
			var dichotomy = new Dichotomy(_function, interval, _accuracy);
			
			//act
			var solve = dichotomy.Process();	
			TestContext.Out.WriteLine($"{dichotomy.IterationCounter} iterated");
			
			//assert
			Assert.IsTrue(solve.EqualWithTolerance(1.4163, _accuracy));
		}

		[Test]
		public void ProcessWithIntervalWithoutRoot_ShouldThrowException()
		{
			//arrange
			var interval = new Interval(10, 20);
			var dichotomy = new Dichotomy(_function, interval, _accuracy);
			
			//act
			var exception = Assert.Throws<Exception>(() => dichotomy.Process());
			TestContext.Out.WriteLine(exception?.Message);

			//assert
			Assert.NotNull(exception);
		}
	}
}

