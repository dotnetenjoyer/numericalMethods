using System;

namespace NumericalMethods.Core.Methods
{
	public class SimpsonIntegration
	{
		private readonly Interval _interval;
		private readonly Func<double, double> _function;
		private readonly int _numberOfStep;
		private readonly double _step;

		public SimpsonIntegration(Func<double, double> function, Interval interval, int numberOfStep)
		{
			_function = function;
			_interval = interval;
			_numberOfStep = numberOfStep;
			_step = _interval.Length / numberOfStep;
		}

		public double Process()
		{
			double integral = 0;

			for (int i = 0; i < _numberOfStep; i += 2)
			{
				double y0 = _function(_interval.A + _step * i);
				double y1 = _function(_interval.A + _step * (i + 1));
				double y2 = _function(_interval.A + _step * (i + 2));

				integral += _step / 3 * (y0 + 4 * y1 + y2);
			}
			
			return integral;
		}
	}
}