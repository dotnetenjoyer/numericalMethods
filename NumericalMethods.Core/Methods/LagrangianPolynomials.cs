using System;
using System.Linq;

namespace NumericalMethods.Core.Methods
{
	public class LagrangianPolynomials
	{
		private readonly Point[] _points;

		public LagrangianPolynomials(Point[] points)
		{
			_points = points;
		}

		public Func<double, double> Process()
		{
			return x => _points.Sum(point => point.Y * FindBasePolynomialValue(point.X, x));
		}

		public double FindBasePolynomialValue(double xi, double x)
		{
			double value = 1;
			
			foreach (var point in _points.Where(x => x.X != xi))
			{
				value *= (x - point.X) / (xi - point.X);
			}
			
			return value;
		}
	}
}