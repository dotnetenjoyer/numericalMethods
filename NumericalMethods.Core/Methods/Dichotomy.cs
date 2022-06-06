using System;

namespace NumericalMethods.Core.Methods
{
	public class Dichotomy
	{
		private readonly Func<double, double> _function;
		private readonly Interval _interval;
		private readonly double _accuracy;
		private int _iterationCounter;

		public Dichotomy(Func<double, double> function, Interval interval, double accuracy)
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
			
			double midpoint = 0;

			while (interval.Length > _accuracy)
			{
				if (IsRootOfEquation(midpoint))
					break;

				midpoint = (interval.A + interval.B) / 2;

				if (_function(midpoint) * _function(interval.A) > 0)
				{
					interval.A = midpoint;
				}
				else
				{
					interval.B = midpoint;
				}

				_iterationCounter++;
			}

			return midpoint;
		}

		private bool IntervalHasValue(Interval interval)
		{
			return _function(interval.A) * _function(interval.B) < 0;
		} 

		private bool IsRootOfEquation(double argument)
		{
			return _function(argument) == 0;
		}
	}
}