using System;
using NumericalMethods.Core;
using NumericalMethods.Core.Methods;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class TrapezoidalIntegrationTests
	{
		[Test]
		public void Process_ShouldPass()
		{
			//arrange
			var interval = new Interval(2, 4);
			Func<double, double> function = x => Math.Pow(Math.Log(x), 10 / 7);

			var trapezoidalIntegration = new TrapezoidalIntegration(function, interval, 1000);
			
			//act
			var integral = trapezoidalIntegration.Process();
			
			//assert
			Assert.IsTrue(integral > 2.1);
		}
	}
}