using System;
using NumericalMethods.Core;
using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class SecantTests
	{
		private readonly double _accuracy = 0.0001;
		private readonly Func<double, double> _function = x => Math.Sin(x) + 2 * Math.Pow(x, 2) - 5;
		
		[Test]
		public void ProcessWithIntervalOnNegativeAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(-5, 0);
			var secant = new Secant(_function, _accuracy, interval);

			//act
			var root = secant.Process();
			TestContext.Out.WriteLine($"{secant.IterationCounter} iterated");

			//assert
			Assert.IsTrue(root.EqualWithTolerance(-1.7302, _accuracy));
		}
		
		[Test]
		public void ProcessWithIntervalOnPositiveAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(0, 5);
			var secant = new Secant(_function, _accuracy, interval);
			
			//act
			var root = secant.Process();	
			TestContext.Out.WriteLine($"{secant.IterationCounter} iterated");
			
			//assert
			Assert.IsTrue(root.EqualWithTolerance(1.4163, _accuracy));
		}

		[Test]
		public void ProcessWithIntervalWithoutRoot_ShouldThrowException()
		{
			//arrange
			var interval = new Interval(10, 20);
			var secant = new Secant(_function, _accuracy, interval);
			
			//act
			var exception = Assert.Throws<Exception>(() => secant.Process());
			TestContext.Out.WriteLine(exception?.Message);

			//assert
			Assert.NotNull(exception);
		}
	}
}