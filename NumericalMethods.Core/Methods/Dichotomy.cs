using System;

namespace NumericalMethods.Core.Methods
{
	public class Dichotomy
	{
		private readonly Func<double, double> _function;
		private readonly Interval _interval;
		private readonly double _accuracy;

		public int IterationCounter => _iterationCounter;
		private int _iterationCounter;

		public Dichotomy(Func<double, double> function, Interval interval, double accuracy)
		{
			_function = function;
			_accuracy = accuracy;
			_interval = interval;
		}

		public double Process()
		{
			Interval interval = new Interval(_interval.A, _interval.B);
			double midpoint = 0;

			if (!IntervalHasValue(interval))
			{
				throw new Exception("There is no root on a given interval");
			}
			
			while (IsSolutionNotSatisfyAccuracy(interval))
			{
				if (IsRootOfEquation(midpoint))
					break;

				_iterationCounter++;
				midpoint = (interval.A + interval.B) / 2;
					
				if (AreFunctionValuesFromMidpointAndANegative(midpoint, interval))
				{
					interval.A = midpoint;
				}
				else
				{
					interval.B = midpoint;
				}
			}

			return midpoint;
		}

		private bool IntervalHasValue(Interval interval)
		{
			return _function(interval.A) * _function(interval.B) < 0;
		} 
		
		private bool IsSolutionNotSatisfyAccuracy(Interval interval)
		{
			return interval.B - interval.A > _accuracy;
		}
		
		private bool IsRootOfEquation(double argument)
		{
			return _function(argument) == 0;
		}

		private bool AreFunctionValuesFromMidpointAndANegative(double midpoint, Interval interval)
		{
			return _function(midpoint) * _function(interval.A) > 0;
		}
	}
}