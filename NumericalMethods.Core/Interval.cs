using System;

namespace NumericalMethods.Core
{
	public class Interval
	{
		public double A
		{
			get => a;
			set
			{
				if(value > B)
					throw new Exception("A must be less than B");

				a = value;
			}
		}

		private double a = double.MinValue;

		public double B
		{
			get => b;
			set
			{
				if(value < A)
					throw new Exception("B must be greater than A");

				b = value;

			}
		}

		private double b = double.MaxValue;
		public Interval(double a, double b)
		{
			A = a;
			B = b;
		}
	}
}