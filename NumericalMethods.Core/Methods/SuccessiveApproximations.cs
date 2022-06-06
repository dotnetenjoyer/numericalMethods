using System;
using NumericalMethods.Tests.Extensions;

namespace NumericalMethods.Core.Methods
{
	public class SuccessiveApproximations
	{
		private readonly Func<double, double> _function;
		private readonly Func<double, double> _iterationFunction;
		private readonly double _accuracy;
		private readonly double _firstApproach;

		private int _iterationCounter;
		
		public SuccessiveApproximations(Func<double, double> function, Func<double, double> iterationFunction, double accuracy, double firstApproach)
		{
			_function = function;
			_iterationFunction = iterationFunction;
			_accuracy = accuracy;
			_firstApproach = firstApproach;
		}

		public int IterationCounter => _iterationCounter;

		public double Process()
		{
			double currentApproach = _firstApproach;

			do
			{
				currentApproach = _iterationFunction(currentApproach);
				_iterationCounter++;
			} while (!IsAcceptableRootOfEquation(currentApproach));

			return currentApproach;
		}
		
		private bool IsAcceptableRootOfEquation(double argument)
		{
			var functionValue = _function(argument);
			return functionValue.EqualWithTolerance(0, _accuracy);
		}
	} 
}