using System;
using NumericalMethods.Core;
using NumericalMethods.Core.Methods;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class NewtonCotesIntegrationTests
	{
		[Test]
		public void Process_ShouldPass()
		{
			//arrange
			var interval = new Interval(2, 4);
			Func<double, double> function = x => Math.Pow(Math.Log(x), 10 / 7);

			var newtonCotesIntegration = new NewtonCotesIntegration(function, interval, 1000);
			
			//act
			var integral = newtonCotesIntegration.Process();
			
			//assert
			Assert.IsTrue(integral > 2);
		}
	}
}