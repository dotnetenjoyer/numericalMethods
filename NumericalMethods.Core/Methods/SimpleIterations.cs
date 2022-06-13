using System;

namespace NumericalMethods.Core.Methods
{
	public class SimpleIterations
	{
		protected readonly double[,] Matrix;
		protected readonly double Accuracy;

		protected double[] CurrentApproximateRoots;
		protected double[] PreviousApproximateRoots;
		
		protected int _iterationCounter; 
		
		public SimpleIterations(double[,] matrix, double accuracy)
		{
			Matrix = matrix;
			Accuracy = accuracy;
			CurrentApproximateRoots = new double[NumberOfUnknown];
			PreviousApproximateRoots = new double[NumberOfUnknown];
		}

		public int IterationCounter => _iterationCounter;
		protected int NumberOfUnknown => Matrix.GetLength(0);

		public double[] Process()
		{
			// var matrixNorm = CalculateMatrixNorm();

			// if (matrixNorm > 1)
			// 	throw new Exception("The norm of matrix is greater than one!");
			//
			do
			{
				CalculateNewApproximation();
				_iterationCounter++;
			} while (AreApproximateRootsSatisfyAccuracy() == false);
			
			return PreviousApproximateRoots;
		}

		private double CalculateMatrixNorm()
		{
			double matrixNorm = double.NegativeInfinity;
			
			for (int i = 0; i < NumberOfUnknown; i++)
			{
				double sum = 0;
				
				for (int j = 0; j < NumberOfUnknown; j++)
				{
					sum += Math.Abs(Matrix[i, j]);
				}

				if (sum > matrixNorm)
					matrixNorm = sum;
			}

			return matrixNorm;
		}
		
		private  bool AreApproximateRootsSatisfyAccuracy()
		{
			bool result = true;
				
			for (int i = 0; i < NumberOfUnknown; i++)
			{
				double error = Math.Abs(CurrentApproximateRoots[i] - PreviousApproximateRoots[i]) / Math.Abs(CurrentApproximateRoots[i]);
				result &=  error < Accuracy;
			}
			
			return result;
		} 

		protected virtual void CalculateNewApproximation()
		{
			var newApproximateRoots = new double[NumberOfUnknown];
		
			for (int i = 0; i < NumberOfUnknown; i++)
			{
				double sum = 0;

				for (int j = 0; j < Matrix.GetLength(1); j++)
				{
					sum += j < NumberOfUnknown
						? Matrix[i, j] * CurrentApproximateRoots[j]
						: Matrix[i, j];
				}

				newApproximateRoots[i] = sum;
			}			
		
			PreviousApproximateRoots = CurrentApproximateRoots;
			CurrentApproximateRoots = newApproximateRoots;
		}
	}
}