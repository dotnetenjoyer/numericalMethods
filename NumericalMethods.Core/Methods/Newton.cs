using System;
using NumericalMethods.Tests.Extensions;

namespace NumericalMethods.Core.Methods
{
	public class Newton
	{
		private readonly Func<double, double> _function;
		private readonly Func<double, double> _firstDerivative;
		private readonly Func<double, double> _secondDerivative;
		private readonly double _accuracy;
		private readonly Interval _interval;
		
		private int _iterationCounter;
		
		public Newton(Func<double, double> function, Func<double, double> firstDerivative, Func<double, double> secondDerivative, double accuracy, Interval interval)
		{
			_function = function;
			_firstDerivative = firstDerivative;
			_secondDerivative = secondDerivative;
			_accuracy = accuracy;
			_interval = interval;
		}

		public int IterationCounter => _iterationCounter;
		
		public double Process()
		{
			if(!IntervalHasValue(_interval))
				throw new Exception("There is no root on a given interval");
  			
			double currentApproximation;

			if (_function(_interval.A) * _secondDerivative(_interval.A) > 0)
			{
				currentApproximation = _interval.A;
			}
			else
			{
				currentApproximation = _interval.B;
			}

			while (true)
			{
				if (IsAcceptableRootOfEquation(currentApproximation))
					break;

				_iterationCounter++;

				currentApproximation = CalculateNextApproximation(currentApproximation);
			}

			return currentApproximation;
		}

		private bool IntervalHasValue(Interval interval)
		{
			return _function(interval.A) * _function(interval.B) < 0;
		}
		
		private bool IsAcceptableRootOfEquation(double value)
		{
			var functionValue = _function(value);
			return functionValue.EqualWithTolerance(0, _accuracy);
		}
		
		private double CalculateNextApproximation(double current)
		{
			return current - _function(current) / _firstDerivative(current);
		}
	}
}