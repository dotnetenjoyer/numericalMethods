using System;
using NumericalMethods.Tests.Extensions;

namespace NumericalMethods.Core.Methods
{
	public class SimpleIterations
	{
		private readonly double[,] _coefficientMatrix;
		private readonly double[] _heterogeneities;
		private readonly double _accuracy;

		private double[] _currentApproximation;
		private double[] _previousApproximation;

		private int _iterationCounter; 
		
		public SimpleIterations(double[,] coefficientMatrix, double[] heterogeneities, double accuracy)
		{
			_coefficientMatrix = coefficientMatrix;
			_heterogeneities = heterogeneities;
			_accuracy = accuracy;
		}

		public int IterationCounter => _iterationCounter;
		private int _numberOfUnknowns => _coefficientMatrix.GetLength(1);

		public double[] Process()
		{
			CalculateZeroApproximations();
		
			do
			{
				CalculateNextApproximation();
				_iterationCounter++;
			} while (!AreCurrentApproximationAcceptableEquationRoot());
		
			return _currentApproximation;
		}

		private bool AreCurrentApproximationAcceptableEquationRoot()
		{
			bool result = true;
			double[] errors = new double[_currentApproximation.Length];
			
			for (int i = 0; i < _currentApproximation.Length; i++)
			{
				double error = Math.Abs(_currentApproximation[i] - _previousApproximation[i]) / Math.Abs(_currentApproximation[i]);
				errors[i] = error;
				result &=  error < _accuracy;
			}

			return result;
		}
		
		private void CalculateZeroApproximations()
		{
			var zeroApproximations = new double[_numberOfUnknowns];
			
			for (int i = 0; i < _numberOfUnknowns; i++)
			{
				zeroApproximations[i] = _heterogeneities[i] / _coefficientMatrix[i, i];
			}

			_currentApproximation = zeroApproximations;
		}

		private void CalculateNextApproximation()
		{
			var nextApproximation = new double[_numberOfUnknowns];

			for (int i = 0; i < _numberOfUnknowns; i++)
			{
				double sum = _heterogeneities[i];

				for (int j = 0; j < _numberOfUnknowns; j++)
				{
					if (i == j)
						continue;

					sum +=  _coefficientMatrix[i, j].ReverseMark() * _currentApproximation[j];
				}

				nextApproximation[i] = sum / _coefficientMatrix[i, i];
			}			

			_previousApproximation = _currentApproximation;
			_currentApproximation = nextApproximation;
		}
	}
}