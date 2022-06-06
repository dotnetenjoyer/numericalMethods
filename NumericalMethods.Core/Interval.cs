using System;

namespace NumericalMethods.Core
{
	public class Interval
	{
		private double _a = double.MinValue;
		private double _b = double.MaxValue;
		public Interval(double a, double b)
		{
			A = a;
			B = b;
		}
		
		public double A
		{
			get => _a;
			set
			{
				if(value > B)
					throw new Exception("A must be less than B");

				_a = value;
			}
		}

		public double B
		{
			get => _b;
			set
			{
				if(value < A)
					throw new Exception("B must be greater than A");

				_b = value;

			}
		}

		public double Length => Math.Abs(A - B);
	}
}