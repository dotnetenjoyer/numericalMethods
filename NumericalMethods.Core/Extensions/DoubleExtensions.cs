namespace NumericalMethods.Tests.Extensions
{
	public static class DoubleExtensions
	{
		public static bool EqualWithTolerance(this double value, double other, double tolerance)
		{
			var difference = value - other;
			return difference < tolerance;
		}
	}
}