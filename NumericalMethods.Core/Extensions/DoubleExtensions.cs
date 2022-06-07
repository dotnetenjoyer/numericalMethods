using System;

namespace NumericalMethods.Tests.Extensions
{
	public static class DoubleExtensions
	{
		public static bool EqualWithTolerance(this double value, double other, double tolerance)
		{
			var difference = Math.Abs(value - other);
			return tolerance > difference;
		}
		
		public static double ReverseMark(this double value) => -value;
	}
}