using System;
using NumericalMethods.Tests.Extensions;

namespace NumericalMethods.Core.Methods
{
	public class Secant
	{
		private readonly Func<double, double> _function;
		private readonly double _accuracy;

		private double _previousApproach;
		private double _currentApproach;
		
		private int _iterationCounter;

		public Secant(Func<double, double> function, double accuracy, double zeroApproach, double firstApproach)
		{
			_function = function;
			_accuracy = accuracy;
			_previousApproach = zeroApproach;
			_currentApproach = firstApproach;
		}

		public int IterationCounter => _iterationCounter;

		public double Process()
		{
			double nextApproach;

			do
			{
				nextApproach = CalculateNextApproximation();

				_previousApproach = _currentApproach;
				_currentApproach = nextApproach;
				
				_iterationCounter++;
			} while (!IsAcceptableRootOfEquation(nextApproach));

			return nextApproach;
		}

		private double CalculateNextApproximation()
		{
			return _currentApproach - _function(_currentApproach) * (_currentApproach - _previousApproach) /
				(_function(_currentApproach) - _function(_previousApproach));
		}
		
		private bool IsAcceptableRootOfEquation(double argument)
		{
			var functionValue = _function(argument);
			return functionValue.EqualWithTolerance(0, _accuracy);
		}
	}
}