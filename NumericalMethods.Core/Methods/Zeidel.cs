namespace NumericalMethods.Core.Methods
{
	public sealed class Zeidel : SimpleIterations
	{
		public Zeidel(double[,] matrix, double accuracy) : base(matrix, accuracy)
		{
			
		}
		
		protected override void CalculateNewApproximation()
		{
			var newApproximateRoots = new double[NumberOfUnknown];
		
			for (int i = 0; i < NumberOfUnknown; i++)
			{
				double sum = 0;

				for (int j = 0; j < Matrix.GetLength(1); j++)
				{
					if (j < NumberOfUnknown)
					{
						if (j < i)
							sum += Matrix[i, j] * newApproximateRoots[j];
						else
							sum += Matrix[i, j] * CurrentApproximateRoots[j];
					}
					else
					{
						sum += Matrix[i, j];
					}
				}

				newApproximateRoots[i] = sum;
			}			
		
			PreviousApproximateRoots = CurrentApproximateRoots;
			CurrentApproximateRoots = newApproximateRoots;
		}
	}
}