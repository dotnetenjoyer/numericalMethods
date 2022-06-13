using System;
using NumericalMethods.Core;
using NumericalMethods.Core.Methods;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class LagrangianPolynomialsTests
	{
		private Func<double, double> _function => x => Math.Pow(Math.Log10(x), 10 / 7);

		[Test]
		public void Process_ShouldPass()
		{	
			//arrange
			Point[] points =
			{
				new (6, _function(6)),
				new (9, _function(9)),
				new (12, _function(12))
			};

			var lagrangianPolynomials = new LagrangianPolynomials(points);

			//act
			var interpolationPolynomial = lagrangianPolynomials.Process();
			var error = _function(10.5) - interpolationPolynomial(10.5);
			TestContext.Out.WriteLine($"Error: {error}");
			
			//assert
			Assert.IsTrue(Math.Abs(error) < 0.01);
		}
	}
}