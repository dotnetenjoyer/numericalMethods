using System;
using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class SuccessiveApproximationsTests
	{
		private readonly Func<double, double> _function = x => Math.Sin(x) + 2 * Math.Pow(x, 2) - 5;
		private readonly Func<double, double> _iterationFunction = x => Math.Sqrt((5 - Math.Sin(x)) / 2);
		private readonly double _accuracy = 0.0001;
		
		[Test]
		public void Process_ShouldPass()
		{
			//arrange 
			var firstApproach = -2;
			var successiveApproximations = new SuccessiveApproximations(_function, _iterationFunction, _accuracy, firstApproach);

			//act 
			var root = successiveApproximations.Process();
			TestContext.Out.WriteLine($"{successiveApproximations.IterationCounter} iterated");
			
			//arrange
			Assert.IsTrue(root.EqualWithTolerance(1.4163, _accuracy));
		}
	}
}