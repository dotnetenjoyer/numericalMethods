using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class SimpleIterationsTests
	{
		[Test]
		public void Process()
		{
			//arrange
			double[] heterogeneities = { 0.87, 0.68, -1.78, 1.28 };
			double[,] coefficientMatrix = 
			{
				{ -0.85, -0.08, 0.32, -0.23 },
				{ -0.21, -0.96, 0.11, 0.31 },
				{ 0.51, -0.06, -0.93, -0.17 },
				{ 0.31, -0.45, 0, -1 }
			};
			var accuracy = 0.0001;
			var simpleIterations = new SimpleIterations(coefficientMatrix, heterogeneities, accuracy);
			
			//act
			var roots = simpleIterations.Process();
			
			//arrange
			Assert.IsTrue(roots[0].EqualWithTolerance(0.1167, accuracy));
			Assert.IsTrue(roots[1].EqualWithTolerance(-0.7721, accuracy));
			Assert.IsTrue(roots[2].EqualWithTolerance(2.1916, accuracy));
			Assert.IsTrue(roots[3].EqualWithTolerance(-0.8963, accuracy));
		}
	}
}