using System;

namespace NumericalMethods.Core.Methods
{
	public class NewtonCotesIntegration
	{
		private readonly Interval _interval;
		private readonly Func<double, double> _function;
		private readonly int _numberOfSteps;

		public NewtonCotesIntegration(Func<double, double> function, Interval interval, int numberOfSteps)
		{
			_function = function;
			_interval = interval;
			_numberOfSteps = numberOfSteps;
		}

		public double Process()
		{
			var points = new Point[]
			{
				new (_interval.A, _function(_interval.A)),
				new (_interval.B, _function(_interval.B)),
			};
			
			var lagrangianPolynomials = new LagrangianPolynomials(points);
			var interpolationPolynomial =  lagrangianPolynomials.Process();

			var rectangularIntegration = new RectangularIntegration(interpolationPolynomial, _interval, _numberOfSteps);
			return rectangularIntegration.Process();
		}
	}
}