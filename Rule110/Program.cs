namespace cyxx.Examples
{
	class Rule110
	{
		private static int numIterations = 47;
		private static int[] iteration = new int[50];

		public static void Main()
		{
			iteration[iteration.Length - 2] = 1;

			for (int i = 0; i < numIterations; ++i)
			{
				_printArr(iteration);
				_calculateNextIteration();
			}
		}

		// prints an array to the console as " " for 0, "*" for 1
		private static void _printArr(int[] arr)
		{
			foreach (int i in arr)
				Console.Write(i == 0 ? " " : "*");
			Console.Write('\n');
		}

		// calculates the array for the next epoch
		private static void _calculateNextIteration()
		{
			var next = new int[iteration.Length];
			for (int i = 0; i < iteration.Length; ++i)
				next[i] = _calculateCellLife(i) ? 1 : 0;
			iteration = next;
		}

		// checks the surrounding cells and matches the pattern against a bitmask that checks for cells that should die
		// returns false if the cell at i should die in the next epoch
		// returns true if the cell at i should live in the next epoch
		private static bool _calculateCellLife(int i)
		{
			// edges are ignored
			if (i == 0 || i == iteration.Length - 1)
				return false;

			// converts 3 nums from the array to a int with the value of the binary concat of the nums
			int num = Convert.ToInt32(string.Concat(iteration.Skip(i - 1).Take(3)), 2);
			int[] patterns = new int[] {
				0b000,
				0b100,
				0b111,
				};

			// tests the num against the patterns
			for (int j = 0; j < patterns.Length; ++j)
				if (num == patterns[j])
					return false;

			// cell passed all checks, lives for the next iteration
			return true;
		}
	}
}