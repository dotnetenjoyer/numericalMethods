using System;

namespace NumericalMethods.Core.Methods
{
	public class RectangularIntegration
	{
		private readonly Func<double, double> _function;
		private readonly Interval _interval;
		private readonly int _numberOfStep;
		private readonly double _step;
		
		public RectangularIntegration(Func<double, double> function, Interval interval, int numberOfStep)
		{
			_function = function;
			_interval = interval;
			_numberOfStep = numberOfStep;
			_step = interval.Length / numberOfStep;
		}

		public double Process()
		{
			double integral = 0;

			for (int i = 1; i < _numberOfStep; i++)
			{
				integral += _step * _function(_interval.A + _step * (i - 0.5));
			}

			return integral;
		}
	}
}