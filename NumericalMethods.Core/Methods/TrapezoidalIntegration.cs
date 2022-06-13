using System;

namespace NumericalMethods.Core.Methods
{
	public class TrapezoidalIntegration
	{
		private readonly Func<double, double> _function;
		private readonly Interval _interval;
		private readonly int _numberOfStep;
		private readonly double _step;
		
		public TrapezoidalIntegration(Func<double, double> function, Interval interval, int numberOfStep)
		{
			_function = function;
			_interval = interval;
			_numberOfStep = numberOfStep;
			_step = interval.Length / numberOfStep;
		}

		public double Process()
		{
			double integral = 0;

			for (int i = 0; i < _numberOfStep; i++)
			{
				integral += _step * (_function(_interval.A + _step * i) + _function(_interval.A + _step * (i + 1))) / 2;
			}

			return integral;
		}
	}
}