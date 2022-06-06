using System;
using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class SecantTests
	{
		private readonly Func<double, double> _function = x => Math.Sin(x) + 2 * Math.Pow(x, 2) - 5;
		private readonly double _accuracy = 0.0001;
		
		[Test]
		public void ProcessWithIntervalOnNegativeAxis_ShouldPass()
		{
			//arrange
			double zeroApproach = 0;
			double firstApproach = -1;
			var secant = new Secant(_function, _accuracy, zeroApproach, firstApproach);
			
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
			double zeroApproach = 0;
			double firstApproach = 1;
			var secant = new Secant(_function, _accuracy, zeroApproach, firstApproach);
			
			//act
			var root = secant.Process();	
			TestContext.Out.WriteLine($"{secant.IterationCounter} iterated");
			
			//assert
			Assert.IsTrue(root.EqualWithTolerance(1.4163, _accuracy));
		}
	}
}