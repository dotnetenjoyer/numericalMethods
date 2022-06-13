using NumericalMethods.Core.Methods;
using NumericalMethods.Tests.Extensions;
using NUnit.Framework;

namespace NumericalMethods.Tests
{
	public class ZeidelTests
	{
		[Test]
		public void Process()
		{
			//arrange
			double[,] coefficientMatrix = 
			{
				{0.15, -0.08, 0.32, -0.23, -0.87},
				{-0.21, 0.04, 0.11, 0.31, -0.68},
				{0.51, -0.06, 0.07, -0.17, 1.78},
				{0.31, -0.45, 0, 0, -1.28}
			};	
			
			var accuracy = 0.0001;
			var zeidel = new Zeidel(coefficientMatrix, accuracy);
			
			//act
			var roots = zeidel.Process();
			TestContext.Out.WriteLine($"{zeidel.IterationCounter} iterated");
			
			//arrange
			Assert.IsTrue(roots[0].EqualWithTolerance(0.1167, accuracy));
			Assert.IsTrue(roots[1].EqualWithTolerance(-0.7721, accuracy));
			Assert.IsTrue(roots[2].EqualWithTolerance(2.1916, accuracy));
			Assert.IsTrue(roots[3].EqualWithTolerance(-0.8963, accuracy));
		}
		
		[Test]
		public void Process2()
		{
			//arrange
			double[,] coefficientMatrix = 
			{
				{0.37, 0.18, 0.28, 0.42},
				{-0.21, -0.64, -1.32, -0.66},
				{0.12, -0.81, 0.86, -0.2},
			};	
			
			var accuracy = 0.0001;
			var zeidel = new Zeidel(coefficientMatrix, accuracy);
			
			//act
			var roots = zeidel.Process();
			TestContext.Out.WriteLine($"{zeidel.IterationCounter} iterated");
			
			//arrange
			Assert.IsTrue(roots[0].EqualWithTolerance(0.6258, accuracy));
			Assert.IsTrue(roots[1].EqualWithTolerance(-0.2361, accuracy));
			Assert.IsTrue(roots[2].EqualWithTolerance(0.2221, accuracy));
		}
		
		[Test]
		public void Process3()
		{
			//arrange
			double[,] coefficientMatrix = 
			{
				{ 0, 2.3 / 3.7, -4.5 / 3.7, 2.4 / 3.7 },
				{ -2.5 / 4.7, 0, 7.8 / 4.7, 3.5 / 4.7},
				{ -1.6 / 1.3, -5.3 / 1.3, 0, -2.4 / 1.3 }
			};
			
			var accuracy = 0.0001;
			var zeidel = new Zeidel(coefficientMatrix, accuracy);
			
			//act
			var roots = zeidel.Process();
			TestContext.Out.WriteLine($"{zeidel.IterationCounter} iterated");
			
			//arrange
			Assert.IsTrue(roots[0].EqualWithTolerance(0.1167, accuracy));
			Assert.IsTrue(roots[1].EqualWithTolerance(-0.7721, accuracy));
			Assert.IsTrue(roots[2].EqualWithTolerance(2.1916, accuracy));
			Assert.IsTrue(roots[3].EqualWithTolerance(-0.8963, accuracy));
		}
	}
}