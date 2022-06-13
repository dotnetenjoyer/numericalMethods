using System;

namespace NumericalMethods.Core.Methods
{
	public class NewtonCotes
	{
		private readonly Interval _interval;
		private readonly Func<double, double> _function;

		public NewtonCotes(Interval interval, Func<double, double> function)
		{
			_interval = interval;
			_function = function;
		}
		
		
	}
}