using System;
using NumericalMethods.Core;
using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class NewtonTests
	{
		private readonly Func<double, double> _function = x => Math.Sin(x) + 2 * Math.Pow(x, 2) - 5;
		private readonly Func<double, double> _firstDerivative = x => Math.Cos(x) + 4 * x;
		private readonly Func<double, double> _secondDerivative = x => Math.Cos(x) + 4 * x;
		private readonly double _accuracy = 0.0001;
		
		[Test]
		public void ProcessWithIntervalOnNegativeAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(-5, 0);
			var newton = new Newton(_function, _firstDerivative, _secondDerivative, _accuracy, interval);
			
			//act
			var root = newton.Process();
			TestContext.Out.WriteLine($"{newton.IterationCounter} iterated");
			
			//assert
			Assert.IsTrue(root.EqualWithTolerance(1.4163, _accuracy));
		}
		
		[Test]
		public void ProcessWithIntervalOnPositiveAxis_ShouldPass()
		{
			//arrange
			var interval = new Interval(0, 5);
			var newton = new Newton(_function, _firstDerivative, _secondDerivative, _accuracy, interval);
			
			//act
			var root = newton.Process();
			TestContext.Out.WriteLine($"{newton.IterationCounter} iterated");
			
			//assert
			Assert.IsTrue(root.EqualWithTolerance(1.4163, _accuracy));
		}
		
		[Test]
		public void ProcessWithIntervalWithoutRoot_ShouldThrowException()
		{
			//arrange
			var interval = new Interval(10, 20);
			var newton = new Newton(_function, _firstDerivative, _secondDerivative, _accuracy, interval);
			
			//act
			var exception = Assert.Throws<Exception>(() => newton.Process());
			TestContext.Out.WriteLine(exception?.Message);

			//assert
			Assert.NotNull(exception);
		}
	}
}