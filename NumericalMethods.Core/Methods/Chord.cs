using System;
using NumericalMethods.Tests.Extensions;

namespace NumericalMethods.Core.Methods
{
	public class Chord
	{
		private readonly double _accuracy;
		private readonly Interval _interval;
		private readonly Func<double, double> _function;

		private int _iterationCounter; 
		
		public Chord(Func<double, double> function, double accuracy, Interval interval)
		{
			_function = function;
			_accuracy = accuracy;
			_interval = interval;
		}

		public int IterationCounter => _iterationCounter;

		public double Process()
		{
			Interval interval = new (_interval.A, _interval.B);

			if (!IntervalHasValue(interval))
				throw new Exception("There is no root on a given interval");

			double intersectionX;

			do
			{
				intersectionX = CalculateLineIntersection(interval);

				if (_function(interval.A) * _function(intersectionX) < 0)
					interval.B = intersectionX;
				else
					interval.A = intersectionX;

				_iterationCounter++;
				
			} while (!IsAcceptableRootOfEquation(intersectionX) && interval.Length > _accuracy);

			return intersectionX;
		}
		
		private bool IntervalHasValue(Interval interval)
		{
			return _function(interval.A) * _function(interval.B) < 0;
		}

		private double CalculateLineIntersection(Interval interval)
		{
			return interval.A - _function(interval.A) * (interval.A - interval.B) /
				(_function(interval.A) - _function(interval.B));
		}
		
		private bool IsAcceptableRootOfEquation(double argument)
		{
			var functionValue = _function(argument);
			return functionValue.EqualWithTolerance(0, _accuracy);
		}
	}
}